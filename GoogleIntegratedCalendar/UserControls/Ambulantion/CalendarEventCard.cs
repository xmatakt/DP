using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.UserControls.Dashboard;

namespace EZKO.UserControls.Ambulantion
{
    public partial class CalendarEventCard : UserControl
    {
        private CalendarEvent calendarEvent;
        private VisitUserControl visitControl;

        #region Public properties
        public Color CardHeadingColor
        {
            get { return topPanel.BackColor; }
            set { topPanel.BackColor = value; }
        }
        #endregion

        public CalendarEventCard(CalendarEvent calendarEvent, VisitUserControl visitControl)
        {
            InitializeComponent();

            this.calendarEvent = calendarEvent;
            this.visitControl = visitControl;

            LoadCard();
        }

        #region Private properties
        private string patientName { set { patientNameLabel.Text = value; } }
        #endregion

        #region Private methods
        private void LoadCard()
        {
            try
            {
                patientName = calendarEvent.Patient.FullName;
                SetPatientImage(calendarEvent.Patient.AvatarImagePath);
                SetBorderColor();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Návštevu sa nepodarilo načítať", e);
            }
        }

        private void SetPatientImage(string avatarImagePath)
        {
            try
            {
                if (avatarImagePath != null && System.IO.File.Exists(avatarImagePath))
                {
                    patientIamgePictureBox.Image = Image.FromFile(avatarImagePath);
                }
                else
                    patientIamgePictureBox.Image = Properties.Resources.noUserImage;
            }
            catch (Exception e)
            {
                patientIamgePictureBox.Image = Properties.Resources.noUserImage;
                BasicMessagesHandler.LogException(e);
            }
        }

        private void SetBorderColor()
        {
            CalendarEventColor eventColor = calendarEvent.CalendarEventColor;
            Color color = Color.FromArgb(eventColor.R, eventColor.G, eventColor.B);
            topPanel.BackColor = color;
            rightBorderPanel.BackColor = color;
            leftBorderPanel.BackColor = color;
            bottomBorderPanel.BackColor = color;
        }
        #endregion

        #region UI events
        private void CalendarEventCard_Click(object sender, EventArgs e)
        {
            if(calendarEvent != null)
                visitControl.LoadEvent(calendarEvent);
        }
        #endregion
    }
}
