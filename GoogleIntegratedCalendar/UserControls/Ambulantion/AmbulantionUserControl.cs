using System;
using System.Drawing;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using System.Windows.Forms.Calendar;
using ExceptionHandler;
using DatabaseCommunicator.Classes;

namespace EZKO.UserControls.Ambulantion
{
    public partial class AmbulantionUserControl : UserControl
    {
        private EzkoController ezkoController;
        private DateTime firstDateTime;
        //private GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer;
        public AmbulantionUserControl(EzkoController ezkoController, GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer)
        {
            InitializeComponent();

            monthView.MonthTitleColor = monthView.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView.DaySelectedTextColor = monthView.ForeColor;
            DateTime now = DateTime.Now;

            this.ezkoController = ezkoController;

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
                eventsFlowLayoutPanel.Controls.Clear();
                foreach (var item in ezkoController.GetEvents(filter))
                {
                    CalendarEventCard card = new CalendarEventCard(item, visitUserControl);
                    card.Width = eventsFlowLayoutPanel.Width - 25;

                    //for AutoSize only in vertical direction
                    card.MaximumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);
                    card.MinimumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);

                    eventsFlowLayoutPanel.Controls.Add(card);
                }
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
                eventsFlowLayoutPanel.Controls.Clear();
                foreach (var item in ezkoController.GetEvents(selectionStart, selectionEnd))
                {
                    CalendarEventCard card = new CalendarEventCard(item, visitUserControl);
                    card.Width = eventsFlowLayoutPanel.Width - 25;

                    //for AutoSize only in vertical direction
                    card.MaximumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);
                    card.MinimumSize = new Size(eventsFlowLayoutPanel.Width - 25, 0);

                    eventsFlowLayoutPanel.Controls.Add(card);
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Udalosti sa nepodarilo načítať", e);
            }
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
