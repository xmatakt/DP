using System;
using System.Windows.Forms;
using EZKO.Controllers;

namespace EZKO.UserControls.Dashboard
{
    /// <summary>
    /// User control used in Dashboard to quick search in all existing events
    /// </summary>
    public partial class FindEventUserControl : UserControl
    {
        public FindEventUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the pickedDateTimeLabel.Text to DateTime range selected by the user
        /// </summary>
        /// <param name="selectionStart">Start of the selected DateTime range</param>
        /// <param name="selectionEnd">End of the selected DateTime range</param>
        public void SetPickedDateLabel(DateTime selectionStart, DateTime selectionEnd)
        {
            if (!selectionStart.Date.Equals(selectionEnd.Date))
                pickedDateTimeLabel.Text = selectionStart.ToString("dddd d.MMMM yyyy") + " - " +
                    selectionEnd.ToString("dddd d.MMMM yyyy");
            else
                pickedDateTimeLabel.Text = selectionStart.ToString("dddd d.MMMM yyyy");
        }

        /// <summary>
        /// Sets the pickedDateTimeLabel.Text to selected DateTime
        /// </summary>
        /// <param name="date">Selected DateTime</param>
        public void SetPickedDateLabel(DateTime date)
        {
            pickedDateTimeLabel.Text = date.ToString("dddd d.MMMM yyyy");
        }
        
        /// <summary>
        /// Loads the texts for for this UserControl based on current language of the application
        /// </summary>
        private void FindEventUserControl_Load(object sender, EventArgs e)
        {
            doctorScheduleLabel.Text = LanguageController.GetText(StringKeys.PersonalSchedule);
            if (GlobalSettings.User != null)
                doctorScheduleLabel.Text += " " + GlobalSettings.User;
        }
    }
}
