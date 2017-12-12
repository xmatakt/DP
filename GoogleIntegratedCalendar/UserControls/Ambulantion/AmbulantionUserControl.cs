using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using System.Windows.Forms.Calendar;
using ExceptionHandler;

namespace EZKO.UserControls.Ambulantion
{
    public partial class AmbulantionUserControl : UserControl
    {
        private EzkoController ezkoController;
        //private GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer;
        public AmbulantionUserControl(EzkoController ezkoController)
        {
            InitializeComponent();

            monthView.MonthTitleColor = monthView.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView.DaySelectedTextColor = monthView.ForeColor;

            this.ezkoController = ezkoController;
            //this.calendarSynchronizer = cal

            visitUserControl.SetEzkoController(ezkoController);
            visitUserControl.SetAmbulantionControl(this);
        }

        #region Public methods
        public void UpdateControl()
        {
            visitUserControl.InitializeUserControl();
        }

        public void LoadEvents()
        {
            LoadEvents(monthView.SelectionStart, monthView.SelectionEnd);
        }
        #endregion

        #region Private methods
        private void LoadEvents(DateTime selectionStart, DateTime selectionEnd)
        {
            try
            {
                eventsFlowLayoutPanel.Visible = false;
                eventsFlowLayoutPanel.Controls.Clear();
                foreach (var item in ezkoController.GetEvents(selectionStart, selectionEnd))
                {
                    CalendarEventCard card = new CalendarEventCard(item, visitUserControl);
                    card.Width = eventsFlowLayoutPanel.Width - 25;
                    eventsFlowLayoutPanel.Controls.Add(card);
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Udalosti sa nepodarilo načítať", e);
            }

            eventsFlowLayoutPanel.Visible = true;
        }
        #endregion

        #region UI events
        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            LoadEvents(monthView.SelectionStart, monthView.SelectionEnd);
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
