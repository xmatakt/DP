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
using DatabaseCommunicator.Enums;

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

        public CalendarEventCard(CalendarEvent calendarEvent, VisitUserControl visitControl, bool showImageLabel)
        {
            InitializeComponent();

            imageLabel.Visible = showImageLabel;

            this.calendarEvent = calendarEvent;
            this.visitControl = visitControl;

            LoadCard();
        }

        #region Private properties
        private string patientName { set { patientNameLabel.Text = value; } }
        private string eventStatus { set { statusLabel.Text = value; } }
        #endregion

        #region Private methods
        private void LoadCard()
        {
            try
            {
                eventStatus = calendarEvent.EventState.ToString();
                if (!calendarEvent.IsTemporaryGoogleEvent)
                {
                    patientLabel.Visible = true;
                    patientName = calendarEvent.Patient.FullName;
                }
                else
                {
                    patientLabel.Visible = false;
                    patientName = calendarEvent.Summary;
                }
                noteTextLabel.Text = calendarEvent.Description;
                noteTextLabel.Location = new Point(noteLabel.Location.X + noteLabel.Width, noteTextLabel.Location.Y);

                startTextLabel.Text = calendarEvent.StartDate.ToString("dd-MM-yyyy, HH:mm");
                endTextLabel.Text = calendarEvent.EndDate.ToString("dd-MM-yyyy, HH:mm");
                doctorTextLabel.Text = GetUsersLabel(calendarEvent.Users.Where(x => x.RoleID == (int)UserRoleEnum.Doctor));
                nurseTextLabel.Text = GetUsersLabel(calendarEvent.Users.Where(x => x.RoleID == (int)UserRoleEnum.Nurse));

                SetPlannedActions(calendarEvent.Actions);
                SetInfrastructure(calendarEvent.Infrastructures);
                SetPatientImage(calendarEvent.Patient?.AvatarImagePath);
                SetBorderColor();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Návštevu sa nepodarilo načítať", e);
            }
        }

        private string GetUsersLabel(IEnumerable<User> enumerable)
        {
            string result = "";
            bool isFirst = true;
            foreach (var item in enumerable)
            {
                if(isFirst)
                {
                    result += item.Login;
                    isFirst = false;
                }
                else
                    result += ", " + item.Login;
            }

            return result;
        }

        private void SetPlannedActions(ICollection<DatabaseCommunicator.Model.Action> actions)
        {
            foreach (var item in actions)
            {
                plannedActionsFlowLayoutPanel.Controls.Add(new Label()
                {
                    Text = "• " + item.Name,
                    AutoSize = true,
                    Font = new Font(FontFamily.GenericSansSerif, 9.75f),
                });
            }
        }

        private void SetInfrastructure(ICollection<Infrastructure> infrastructures)
        {
            foreach (var item in infrastructures)
            {
                infrastructureFlowLayoutPanel.Controls.Add(new Label()
                {
                    Text = "• " + item.Name,
                    AutoSize = true,
                    Font = new Font(FontFamily.GenericSansSerif, 9.75f),
                });
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

        private void CalendarEventCard_Resize(object sender, EventArgs e)
        {
            noteTextLabel.MaximumSize = new Size(this.Width - noteTextLabel.Location.X - 10, 0);
        }
        #endregion
    }
}
