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
        private Dictionary<DateTime, int> eventsCountByDate;

        private void InitializeControl()
        {
            try
            {
                calendarSynchronizer = new GoogleCalendarSynchronizer.GoogleCalendarSynchronizer(calendar, "timo");

                LoadEvents(DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(1));
                ShowItems();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri načítaní udalostí", e);
            }
        }

        #region Calendar events loading
        private void LoadEvents(DateTime startDate, DateTime endDate)
        {
            List<CalendarItem> googleEvents = LoadGoogleCalendarEvents(startDate, endDate);
            List<CalendarItem> dbEvents = LoadDbCalendarItems(startDate, endDate);

            calendarItems = UniteEvents(googleEvents, dbEvents);
        }

        private List<CalendarItem> LoadGoogleCalendarEvents(DateTime startDate, DateTime endDate)
        {
            // Exception handled in GetCalendarItem method
            return calendarSynchronizer.GetCalendarItems(startDate, endDate);
        }

        private List<CalendarItem> LoadDbCalendarItems(DateTime startDate, DateTime endDate)
        {
            IQueryable<CalendarEvent> dbEvents = ezkoController.GetEvents(startDate, endDate);

            // for future use - color of days in monthview can differs based on count of events on day
            // not implemented yet
            foreach (var dbEvent in dbEvents)
            {
                if (!eventsCountByDate.ContainsKey(dbEvent.StartDate.Date))
                    eventsCountByDate.Add(dbEvent.StartDate.Date, 1);
                else
                    eventsCountByDate[dbEvent.StartDate.Date]++;
            }

            monthView.EventsCountByDate = eventsCountByDate;
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
            CalendarItem result = new CalendarItem(calendar, calendarEvent.StartDate, calendarEvent.EndDate, calendarEvent.Summary,
                calendarEvent.ToString(), calendarEvent.IsDeleted);
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
        public GoogleIntegratedCalendarControl(EzkoController ezkoController)
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

            eventsCountByDate = new Dictionary<DateTime, int>();
            DateTime now = DateTime.Now;
            calendar.ViewStart = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            calendar.ViewEnd = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            findEventUserControl.SetPickedDateLabel(calendar.ViewStart, calendar.ViewEnd);

            this.ezkoController = ezkoController;
            visitUserControl1.SetCalendarControl(this);
            visitUserControl1.SetEzkoController(ezkoController);

            InitializeControl();
        }

        public void AddCalendarEvent(CalendarEvent calendarEvent)
        {
            CalendarItem newItem = CreateCalendarItem(calendarEvent);
            calendarItems.Add(newItem);
            ShowItems();

            calendarSynchronizer.UploadEvent(newItem);
        }

        public void UpdateCalendarEvent(CalendarEvent calendarEvent)
        {
            CalendarItem calendarItem = calendarItems.FirstOrDefault(x => x.DatabaseEntityID == calendarEvent.ID);

            calendarItem.Text = calendarEvent.Summary;
            calendarItem.Description = calendarEvent.ToString();
            calendarItem.StartDate = calendarEvent.StartDate;
            calendarItem.EndDate = calendarEvent.EndDate;

            if (calendarItem != null)
            {
                if (calendarSynchronizer.UpdateEvent(calendarItem))
                {
                    //TODO: MessageBox?
                }
                else
                {
                    //TODO: MessageBox?
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

            if(calendarSynchronizer.UpdateEvent(calendarItem))
            {
                //TODO: MessageBox?
            }
            else
            {
                //TODO: MessageBox?
            }

            ShowItems();
        }
        #endregion

        #region private methods
        private bool SynchronizeEvents()
        {
            List<CalendarItem> googleUploadItems = new List<CalendarItem>();
            List<CalendarItem> googleUpdateItems = new List<CalendarItem>();
            List<CalendarItem> dbUploadItems = new List<CalendarItem>();
            List<CalendarItem> dbUpdateItems = new List<CalendarItem>();

            foreach (var calendarItem in calendarItems.Where(x => !x.IsSynchronized))
            {
                if (calendarItem.DatabaseEntityID == null)
                {
                    dbUploadItems.Add(calendarItem);
                    if (calendarItem.GoogleEventID == null)
                        googleUploadItems.Add(calendarItem);
                    else
                        googleUpdateItems.Add(calendarItem);
                }
                else
                {
                    if (calendarItem.GoogleEventID == null)
                    {
                        calendarItem.GenerateGoogleEventID();
                        googleUploadItems.Add(calendarItem);
                    }
                    else
                        googleUpdateItems.Add(calendarItem);
                    dbUpdateItems.Add(calendarItem);
                }
            }

            bool dbUploadResult = ezkoController.AddCalendarEvents(dbUploadItems);
            bool dbUpdateResult = ezkoController.UpdateCalendarEvents(dbUpdateItems);
            bool googleUploadResult = calendarSynchronizer.UploadEvents(googleUploadItems);
            bool googleUpdateResult = calendarSynchronizer.UpdateEvents(googleUpdateItems);

            if (!dbUploadResult)
                BasicMessagesHandler.ShowErrorMessage("Počas vytvárania nových udalostí do databázy sa vyskytla chyba");
            if (!dbUpdateResult)
                BasicMessagesHandler.ShowErrorMessage("Počas synchronizácie udalostí v databáze sa vyskytla chyba");
            if (!googleUploadResult)
                BasicMessagesHandler.ShowErrorMessage("Počas vytvárania nových udalostí v Google kalendári sa vyskytla chyba");
            if (!googleUpdateResult)
                BasicMessagesHandler.ShowErrorMessage("Počas synchronizácie udalostí v Google kalendári sa vyskytla chyba");


            return dbUploadResult && dbUpdateResult && googleUploadResult && googleUpdateResult;
        }

        private void ChangeIsSynchronizedValues(bool value)
        {
            foreach (var item in calendarItems)
            {
                item.IsSynchronized = value;
            }
        }
        #endregion

        #region UI events
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Treba vyriesit uploadovanie eventov z google kalendara" +
                "\nktore nie su v DB (kvoli PatientID)" +
                "\nSYNCHRONIZACIA NEPREBEHNE");
            return;

            if (SynchronizeEvents())
            {
                if (ezkoController.SaveChanges())
                {
                    ChangeIsSynchronizedValues(true);
                    LoadEvents(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1));
                    ShowItems();
                }
                else
                    BasicMessagesHandler.ShowErrorMessage("Počas ukladania udalostí do databázy sa vyskytla chyba");
            }
        }

        private void calendar_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            //calendarItems.Add(e.Item);
        }

        private void calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //calendar.ActivateEditMode();
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
            e.Item.IsSynchronized = false;
        }

        private void calendar_ItemTextEdited(object sender, CalendarItemCancelEventArgs e)
        {
            e.Item.IsSynchronized = false;
        }

        private void calendar_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            findEventUserControl.SetPickedDateLabel(e.CalendarDay.Date);
        }

        private void GoogleIntegratedCalendarControl_Resize(object sender, EventArgs e)
        {
            visitUserControl1.SetMaximumHeight(Size.Height);
        }

        private void calendar_ItemClick(object sender, CalendarItemEventArgs e)
        {
            if (e.Item != null && e.Item.DatabaseEntityID.HasValue)
            {
                visitUserControl1.LoadEvent(e.Item.DatabaseEntityID.Value);
            }
        }
        #endregion
    }
}
