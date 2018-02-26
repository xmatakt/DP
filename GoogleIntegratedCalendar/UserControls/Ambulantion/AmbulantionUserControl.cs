using System;
using System.Drawing;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using System.Windows.Forms.Calendar;
using ExceptionHandler;
using DatabaseCommunicator.Classes;
using System.Collections.Generic;

namespace EZKO.UserControls.Ambulantion
{
    public partial class AmbulantionUserControl : UserControl
    {
        private EzkoController ezkoController;
        private DateTime firstDateTime;
        private bool loadDurations = true;
        //private GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer;
        public AmbulantionUserControl(GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer)
        {
            InitializeComponent();

            monthView.MonthTitleColor = monthView.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView.DaySelectedTextColor = monthView.ForeColor;
            DateTime now = DateTime.Now;
            monthView.EventsDurationByDate = new Dictionary<DateTime, int>();

            ezkoController = GlobalSettings.EzkoController;

            visitUserControl.SetEzkoController(ezkoController);
            visitUserControl.SetAmbulantionControl(this);
            visitUserControl.SetCalendarSynchronizer(calendarSynchronizer);

            filterEventUserControl.SetEzkoController(ezkoController);
            filterEventUserControl.SetAmbulantionContorlPanel(this);
            filterEventUserControl.SetTitleLabel(monthView.SelectionStart, monthView.SelectionEnd);
        }

        #region Public methods
        public void UpdateControl()
        {
            visitUserControl.InitializeUserControl();
        }

        public void LoadEvents()
        {
            if (!filterEventUserControl.ApplyFilter)
            {
                if (monthView.SelectionStart <= firstDateTime)
                {
                    DateTime now = DateTime.Now;
                    monthView.SelectionStart = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    monthView.SelectionEnd = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                }
                else
                    LoadEvents(monthView.SelectionStart, monthView.SelectionEnd);
            }
            else
                LoadEvents(filterEventUserControl.Filter);
        }

        public void LoadEvents(CalendarEventFilter filter)
        {
            try
            {
                loadDurations = true;
                monthView.EventsDurationByDate = new Dictionary<DateTime, int>();
                eventsFlowLayoutPanel.Controls.Clear();
                foreach (var item in ezkoController.GetEvents(filter))
                {
                    CalendarEventCard card = new CalendarEventCard(item, visitUserControl,
                        item.StateID == (int)DatabaseCommunicator.Enums.EventStateEnum.Payed);
                    card.Width = eventsFlowLayoutPanel.Width - 25;

                    //for AutoSize only in vertical direction
                    card.MaximumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);
                    card.MinimumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);

                    eventsFlowLayoutPanel.Controls.Add(card);

                    UpdateDurations(item.StartDate, item.EndDate, false);
                }

                monthView.Invalidate();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Udalosti sa nepodarilo načítať", e);
            }
        }
        #endregion

        #region Private methods
        private void LoadEvents(DateTime selectionStart, DateTime selectionEnd)
        {
            try
            {
                if (loadDurations)
                    LoadDurations(DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(1));

                eventsFlowLayoutPanel.Controls.Clear();
                foreach (var item in ezkoController.GetEvents(selectionStart, selectionEnd))
                {
                    CalendarEventCard card = new CalendarEventCard(item, visitUserControl,
                        item.StateID == (int)DatabaseCommunicator.Enums.EventStateEnum.Payed);
                    card.Width = eventsFlowLayoutPanel.Width - 25;

                    //for AutoSize only in vertical direction
                    card.MaximumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);
                    card.MinimumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);

                    eventsFlowLayoutPanel.Controls.Add(card);
                }

                monthView.Invalidate();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Udalosti sa nepodarilo načítať", e);
            }
        }

        private void LoadDurations(DateTime startDate, DateTime endDate)
        {
            monthView.EventsDurationByDate = new Dictionary<DateTime, int>();
            foreach (var item in ezkoController.GetEvents(startDate, endDate))
                UpdateDurations(item.StartDate, item.EndDate, false);

            loadDurations = false;
        }

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
        #endregion

        #region UI events
        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            LoadEvents(monthView.SelectionStart, monthView.SelectionEnd);
            filterEventUserControl.SetTitleLabel(monthView.SelectionStart, monthView.SelectionEnd);
        }

        private void AmbulantionUserControl_Resize(object sender, EventArgs e)
        {
            if (monthView.SelectionStart != null && monthView.SelectionEnd != null)
                LoadEvents(monthView.SelectionStart, monthView.SelectionEnd);

            visitUserControl.SetMaximumHeight(Size.Height);
        }
        #endregion
    }
}
