using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using System.Windows.Forms.Calendar;
using DatabaseCommunicator.Model;
using ExceptionHandler;

namespace EZKO.UserControls.Dashboard
{
    /// <summary>
    /// User control used as Dashboard
    /// </summary>
    public partial class GoogleIntegratedCalendarControl : UserControl
    {
        private List<CalendarItem> calendarItems;
        private EzkoController ezkoController;
        private GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer;

        public GoogleIntegratedCalendarControl(ref GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer)
        {
            InitializeComponent();

            CultureInfo culture = new CultureInfo(GlobalSettings.LanguagePrefix);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            //Monthview colors
            monthView.MonthTitleColor = monthView.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView.DaySelectedTextColor = monthView.ForeColor;

            DateTime now = DateTime.Now;
            calendar.ViewStart = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            calendar.ViewEnd = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            findEventUserControl.SetPickedDateLabel(calendar.ViewStart, calendar.ViewEnd);

            ezkoController = GlobalSettings.EzkoController;
            visitUserControl.SetCalendarControl(this);
            visitUserControl.SetEzkoController(ezkoController);

            //findEventUserControl.SetEzkoController(ezkoController);
            findEventUserControl.SetVisitUserControl(visitUserControl);
            findEventUserControl.SetCalendarControl(this);

            InitializeControl();
            calendarSynchronizer = this.calendarSynchronizer;
        }

        private void InitializeControl()
        {
            try
            {
                calendarSynchronizer = new GoogleCalendarSynchronizer.GoogleCalendarSynchronizer(calendar, GlobalSettings.GoogleCalendarUserName);

                LoadEvents(DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(1));
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri načítaní udalostí", ex);
            }
        }

        private void ScrollToTimeUnit(CalendarTimeScaleUnit timeScaleUnit = null)
        {
            try
            {
                if (timeScaleUnit == null)
                    timeScaleUnit = calendar.GetTimeUnit(DateTime.Now, true);

                calendar.ScrollCalendarControl(timeScaleUnit.Index);
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri skrolovaní stredného panelu", ex);
            }
        }

        #region Calendar events loading
        private void LoadEvents(DateTime startDate, DateTime endDate)
        {

            //List<CalendarItem> googleEvents = LoadGoogleCalendarEvents(startDate, endDate);
            List<CalendarItem> dbEvents = LoadDbCalendarItems(startDate, endDate);

            //calendarItems = UniteEvents(googleEvents, dbEvents);
            calendarItems = dbEvents;
            ShowItems();
        }

        private List<CalendarItem> LoadGoogleCalendarEvents(DateTime startDate, DateTime endDate)
        {
            // Exception handled in GetCalendarItem method
            return calendarSynchronizer.GetGoogleCalendarItems(startDate, endDate);
        }

        private List<CalendarItem> LoadDbCalendarItems(DateTime startDate, DateTime endDate)
        {
            IQueryable<CalendarEvent> dbEvents = ezkoController.GetEvents(startDate, endDate);
            monthView.EventsDurationByDate = new Dictionary<DateTime, int>();

            foreach (var dbEvent in dbEvents)
            {
                UpdateDurations(dbEvent.StartDate, dbEvent.EndDate, false);
                //if (!monthView.EventsDurationByDate.ContainsKey(dbEvent.StartDate.Date))
                //    monthView.EventsDurationByDate.Add(dbEvent.StartDate.Date, (int)(dbEvent.EndDate - dbEvent.StartDate).TotalMinutes);
                //else
                //    monthView.EventsDurationByDate[dbEvent.StartDate.Date] += (int)(dbEvent.EndDate - dbEvent.StartDate).TotalMinutes;
            }

            return CreateCalendarItemsFromDbEvents(dbEvents);
        }

        private List<CalendarItem> CreateCalendarItemsFromDbEvents(IQueryable<CalendarEvent> dbEvents)
        {
            List<CalendarItem> result = new List<CalendarItem>();
            foreach (var item in dbEvents)
            {
                result.Add(CreateCalendarItem(item));
            }

            return result;
        }

        private CalendarItem CreateCalendarItem(CalendarEvent calendarEvent)
        {
            CalendarItem result = null;
            if (!calendarEvent.IsTemporaryGoogleEvent)
            {
                result = new CalendarItem(calendar, calendarEvent.StartDate, calendarEvent.EndDate, calendarEvent.Summary,
                    calendarEvent.Details, calendarEvent.IsDeleted);
            }
            else
            {
                result = new CalendarItem(calendar, calendarEvent.StartDate, calendarEvent.EndDate, calendarEvent.Summary,
                    calendarEvent.Description, calendarEvent.IsDeleted);
            }

            if (calendarEvent.StateID == (int)DatabaseCommunicator.Enums.EventStateEnum.Payed)
            {
                result.Image = Properties.Resources.euro_sign2_black_16;
                result.ImageAlign = CalendarItemImageAlign.East;
            }

            result.GoogleEventID = calendarEvent.GoogleEventID;
            result.DatabaseEntityID = calendarEvent.ID;
            result.ApplyColor(Color.FromArgb(
                calendarEvent.CalendarEventColor.R,
                calendarEvent.CalendarEventColor.G,
                calendarEvent.CalendarEventColor.B));
            
            return result;
        }

        private List<CalendarItem> UniteEvents(List<CalendarItem> googleEvents, List<CalendarItem> dbEvents)
        {
            List<CalendarItem> result = new List<CalendarItem>();
            List<int> dbEventIdsToDelete = new List<int>();

            IEnumerable<CalendarItem> onlyGoogleEvents = googleEvents.Where(x =>
                !dbEvents.Where(y => y.GoogleEventID != null)
                    .Select(y => y.GoogleEventID)
                    .Contains(x.GoogleEventID)
            );

            IEnumerable<CalendarItem> onlyDbEvents = dbEvents.Where(x =>
                !googleEvents.Select(y => y.GoogleEventID).Contains(x.GoogleEventID)).ToList();

            List<string> commonEventsGoogleIds =
                googleEvents.Select(x => x.GoogleEventID).Where(x =>
                dbEvents.Where(y => y.GoogleEventID != null).Select(y => y.GoogleEventID).Contains(x)).ToList();

            // if events are only on google, mark them as unsynchronized and show to user
            //foreach (var googleEvent in onlyGoogleEvents)
            //{
            //    googleEvent.IsSynchronized = false;
            //    result.Add(googleEvent);
            //}

            // if events are only in database
            foreach (var dbEvent in onlyDbEvents)
            {
                // if event doesn't have GoogleId, mark it as unsynchronized and show to user
                if (dbEvent.GoogleEventID == null)
                {
                    dbEvent.IsSynchronized = false;
                    result.Add(dbEvent);
                }
                // if event has GoogleId, mark it as deleted
                //else
                //    dbEventIdsToDelete.Add(dbEvent.DatabaseEntityID.Value);
                // if event has GoogleId, show it to the user
                else
                    result.Add(dbEvent);
            }

            // events which are common
            foreach (var googleId in commonEventsGoogleIds)
            {
                var googleEvent = googleEvents.First(x => x.GoogleEventID == googleId);
                var dbEvent = dbEvents.First(x => x.GoogleEventID == googleId);

                // equal events just show to user
                if (googleEvent.Equals(dbEvent))
                {
                    dbEvent.IsSynchronized = true;
                    result.Add(dbEvent);
                }
                // if they aren't equal, get google event, mark it as unsynchronized and show to the user
                else
                {
                    googleEvent.IsSynchronized = false;
                    googleEvent.DatabaseEntityID = dbEvent.DatabaseEntityID;
                    googleEvent.BackgroundColor = dbEvent.BackgroundColor;
                    googleEvent.BackgroundColorLighter = dbEvent.BackgroundColorLighter;
                    result.Add(googleEvent);
                }
            }

            if (!ezkoController.DeleteEvents(dbEventIdsToDelete))
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri odstraňované udalostí");
            }

            return result;
        }

        private void ShowItems()
        {
            try
            {
                if (calendar != null && calendar.Items != null && calendar.Items.Count > 0)
                    calendar.Items.Clear();


                if (calendarItems == null)
                    return;

                foreach (CalendarItem item in calendarItems)
                {
                    if (calendar.ViewIntersects(item))
                    {
                        if (!item.IsDeleted)
                            calendar.Items.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri zobrazovaní udalostí", e);
            }
        }
        #endregion

        #region public methods

        private void UpdateDurations(DateTime startDate, DateTime endDate, bool invalidateMonthView)
        {
            if (!monthView.EventsDurationByDate.ContainsKey(startDate.Date))
                monthView.EventsDurationByDate.Add(startDate.Date, (int)(endDate - startDate).TotalMinutes);
            else
                monthView.EventsDurationByDate[startDate.Date] += (int)(endDate - startDate).TotalMinutes;

            if (invalidateMonthView)
                monthView.Invalidate();
        }

        private void UpdateDurations(bool invalidateMonthView, DateTime startDate, DateTime endDate)
        {
            int originalEventDuration = (int)(endDate - startDate).TotalMinutes;
            monthView.EventsDurationByDate[startDate.Date] -= originalEventDuration;

            if (invalidateMonthView)
                monthView.Invalidate();
        }

        public void AddCalendarEvent(CalendarEvent calendarEvent)
        {
            CalendarItem newItem = CreateCalendarItem(calendarEvent);
            calendarItems.Add(newItem);

            UpdateDurations(calendarEvent.StartDate, calendarEvent.EndDate, true);

            ShowEvent(calendarEvent);

            if (!calendarSynchronizer.UploadEvent(newItem, ezkoController))
                BasicMessagesHandler.ShowInformationMessage("Nepodarilo sa uložiť udalosť " + calendarEvent.Summary + " do Google kalendára.");
        }

        public void UpdateCalendarEvent(CalendarEvent calendarEvent)
        {
            CalendarItem calendarItem = calendarItems.FirstOrDefault(x => x.DatabaseEntityID == calendarEvent.ID);

            if (calendarItem != null)
            {
                UpdateDurations(false, calendarItem.StartDate, calendarItem.EndDate);

                calendarItem.Text = calendarEvent.Summary;
                calendarItem.Description = calendarEvent.Details;
                calendarItem.StartDate = calendarEvent.StartDate;
                calendarItem.EndDate = calendarEvent.EndDate;
                calendarItem.ApplyColor(Color.FromArgb(
                    calendarEvent.CalendarEventColor.R,
                    calendarEvent.CalendarEventColor.G,
                    calendarEvent.CalendarEventColor.B));

                UpdateDurations(calendarEvent.StartDate, calendarEvent.EndDate, true);

                if (calendarSynchronizer.UpdateEvent(calendarItem, ezkoController))
                {
                    //TODO: MessageBox?
                }
                else
                {
                    BasicMessagesHandler.ShowInformationMessage("Nepodarilo sa aktualizovať udalosť " + calendarEvent.Summary + " v Google kalendári.");
                }

                ShowItems();
            }
            else
            {
                //TODO: ?
            }
        }

        public void RemoveCalendarItem(CalendarEvent calendarEvent)
        {
            CalendarItem calendarItem = calendarItems.FirstOrDefault(x => x.DatabaseEntityID == calendarEvent.ID);

            if (calendarItem != null)
                calendarItem.IsDeleted = true;

            UpdateDurations(true, calendarItem.StartDate, calendarItem.EndDate);

            if (calendarSynchronizer.UpdateEvent(calendarItem, ezkoController))
            {
                //TODO: MessageBox?
            }
            else
            {
                //TODO: MessageBox?
            }

            ShowItems();
        }

        public void UpdateControl()
        {
            visitUserControl.InitializeUserControl();
            findEventUserControl.UpdateControl();
            LoadEvents(DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(1));
            ScrollToTimeUnit();
        }

        public void ShowEvent(CalendarEvent calendarEvent)
        {
            calendar.ViewStart = calendarEvent.StartDate;
            calendar.ViewEnd = calendarEvent.StartDate;
            monthView.SelectionStart = new DateTime(calendarEvent.StartDate.Year, calendarEvent.StartDate.Month, calendarEvent.StartDate.Day, 0, 0, 0);
            monthView.SelectionEnd = calendarEvent.StartDate;

            CalendarItem matchingCalendarItem = calendarItems.FirstOrDefault(x => x.DatabaseEntityID == calendarEvent.ID);
            if (matchingCalendarItem != null)
                matchingCalendarItem.Selected = true;

            ShowItems();
            ScrollToTimeUnit(calendar.GetTimeUnit(calendarEvent.StartDate));
        }

        public void ShowDay(DateTime day)
        {
            monthView.SelectionStart = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            monthView.SelectionEnd = monthView.SelectionStart;
            monthView.ViewStart = monthView.SelectionStart;
            monthView.Invalidate();
        }
        #endregion

        #region private methods
        private bool SynchronizeEvents()
        {
            return false;
            //List<CalendarItem> googleUploadItems = new List<CalendarItem>();
            //List<CalendarItem> googleUpdateItems = new List<CalendarItem>();
            //List<CalendarItem> dbUploadItems = new List<CalendarItem>();
            //List<CalendarItem> dbUpdateItems = new List<CalendarItem>();

            //foreach (var calendarItem in calendarItems.Where(x => !x.IsSynchronized))
            //{
            //    if (calendarItem.DatabaseEntityID == null)
            //    {
            //        dbUploadItems.Add(calendarItem);
            //        if (calendarItem.GoogleEventID == null)
            //            googleUploadItems.Add(calendarItem);
            //        else
            //            googleUpdateItems.Add(calendarItem);
            //    }
            //    else
            //    {
            //        if (calendarItem.GoogleEventID == null)
            //        {
            //            calendarItem.GenerateGoogleEventID();
            //            googleUploadItems.Add(calendarItem);
            //        }
            //        else
            //            googleUpdateItems.Add(calendarItem);
            //        dbUpdateItems.Add(calendarItem);
            //    }
            //}

            //bool dbUploadResult = ezkoController.AddCalendarEvents(dbUploadItems);
            //bool dbUpdateResult = ezkoController.UpdateCalendarEvents(dbUpdateItems);
            //bool googleUploadResult = calendarSynchronizer.UploadEvents(googleUploadItems);
            //bool googleUpdateResult = calendarSynchronizer.UpdateEvents(googleUpdateItems);

            //if (!dbUploadResult)
            //    BasicMessagesHandler.ShowErrorMessage("Počas vytvárania nových udalostí do databázy sa vyskytla chyba");
            //if (!dbUpdateResult)
            //    BasicMessagesHandler.ShowErrorMessage("Počas synchronizácie udalostí v databáze sa vyskytla chyba");
            //if (!googleUploadResult)
            //    BasicMessagesHandler.ShowErrorMessage("Počas vytvárania nových udalostí v Google kalendári sa vyskytla chyba");
            //if (!googleUpdateResult)
            //    BasicMessagesHandler.ShowErrorMessage("Počas synchronizácie udalostí v Google kalendári sa vyskytla chyba");


            //return dbUploadResult && dbUpdateResult && googleUploadResult && googleUpdateResult;
        }
        #endregion

        #region UI events
        private void calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            if (e.Item != null && e.Item.DatabaseEntityID.HasValue)
            {
                //calendar.TimeUnitsOffset = 0;
                visitUserControl.LoadEvent(e.Item.DatabaseEntityID.Value);
                visitUserControl.SetEventTimes(e.Item.StartDate, e.Item.EndDate);
            }
        }

        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            calendar.SetViewRange(monthView.SelectionStart, monthView.SelectionEnd);
            calendar.Focus();

            findEventUserControl.SetPickedDateLabel(monthView.SelectionStart, monthView.SelectionEnd);
        }

        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            ShowItems();
        }

        private void calendar_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            e.Item.IsSynchronized = false;
            e.Item.IsDeleted = true;
        }

        private void calendar_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            //e.Item.IsSynchronized = false;
            visitUserControl.SetEventTimes(e.Item.StartDate, e.Item.EndDate);
        }

        private void calendar_ItemTextEdited(object sender, CalendarItemCancelEventArgs e)
        {
            e.Item.IsSynchronized = false;
        }

        private void calendar_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            findEventUserControl.SetPickedDateLabel(e.CalendarDay.Date);
            monthView.SelectionStart = e.CalendarDay.Date;
            monthView.SelectionEnd = e.CalendarDay.Date;
        }

        private void GoogleIntegratedCalendarControl_Resize(object sender, EventArgs e)
        {
            visitUserControl.SetMaximumHeight(Size.Height);
        }

        private void calendar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CalendarTimeScaleUnit item = calendar.HitTest(e.Location) as CalendarTimeScaleUnit;
                if (item != null)
                {
                    visitUserControl.ResetVisitPanel(Enums.WorkingTypeEnum.Creating);
                    visitUserControl.SetEventStartDate(item.Date);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                monthviewSettingsMenuStrip.Show(calendar, e.Location);
            }
        }

        private void minuteInterval5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar.TimeScale = CalendarTimeScale.FiveMinutes;
        }

        private void minuteInterval10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar.TimeScale = CalendarTimeScale.TenMinutes;
        }

        private void minuteInterval15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar.TimeScale = CalendarTimeScale.FifteenMinutes;
        }

        private void minuteInterval30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar.TimeScale = CalendarTimeScale.ThirtyMinutes;
        }

        private void minuteInterval60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar.TimeScale = CalendarTimeScale.SixtyMinutes;
        }
        private void GoogleIntegratedCalendarControl_Load(object sender, EventArgs e)
        {
            ScrollToTimeUnit();
        }

        #endregion
    }
}
