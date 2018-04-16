using System;
using System.Windows.Forms;

namespace EZKO.Forms
{
    /// <summary>
    /// Form for picking date and time for calendar events
    /// </summary>
    public partial class DateTimePickerForm : Form
    {
        //public property to store date piced by user
        public DateTime PickedDateTime;

        public DateTimePickerForm(DateTime? value)
        {
            InitializeComponent();

            //Set language for GUI items
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(GlobalSettings.LanguagePrefix);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            if (value.HasValue)
            {
                datePicker.Value = value.Value;
                hourNumericUpDown.Value = value.Value.Hour;
                minuteNumericUpDown.Value = value.Value.Minute;
            }
            else
            {
                DateTime now = DateTime.Now;
                datePicker.Value = now;
                hourNumericUpDown.Value = now.Hour;
                if (now.Minute % 5 != 0)
                {
                    decimal newValue = now.Minute + (5 - now.Minute % 5);
                    if (newValue != 60)
                        minuteNumericUpDown.Value = newValue;
                    else
                    {
                        minuteNumericUpDown.Value = 0;
                        if (hourNumericUpDown.Value == 23)
                        {
                            hourNumericUpDown.Value = 0;
                            datePicker.Value.AddDays(1);
                        }
                        else
                            hourNumericUpDown.Value++;
                    }
                }
                else
                    minuteNumericUpDown.Value = now.Minute;
            }

            PickedDateTime = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day,
                (int)hourNumericUpDown.Value, (int)minuteNumericUpDown.Value, 0);
            infoLabel.Visible = false;
        }

        /// <summary>
        /// We want to allows only values divisible by 5 for minutes
        /// </summary>
        /// <returns>Value or 0 or 5</returns>
        private int GetMinuteValue()
        {
            int result = (int)minuteNumericUpDown.Value;
            int rest = result % 5; 
            if (rest != 0)
            {
                if (rest <= 2)
                    result -= rest;
                else
                    result += 5 - rest;
            }

            return result;
        }

        /// <summary>
        /// Allow only values divisible by 5
        /// </summary>
        private void ValidateValue()
        {
            int value = (int)minuteNumericUpDown.Value;
            if ((value % 5) != 0)
                infoLabel.Visible = true;
            else
                infoLabel.Visible = false;
        }

        private void DateTimePickerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PickedDateTime = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day,
            (int)hourNumericUpDown.Value, GetMinuteValue(), 0);
        }
    
        private void minuteNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ValidateValue();
        }

        private void minuteNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateValue();
        }

        private void DateTimePickerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
