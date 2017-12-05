using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.UserControls.Other
{
    class LabeledNumericUpDown : NumericUpDown
    {
        private bool valueChanged = false;
        private string labelText = Controllers.LanguageController.GetText(StringKeys.Minutes);

        public LabeledNumericUpDown()
        {
            ValueChanged += LabeledNumericUpDown_ValueChanged;
        }

        private void LabeledNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            valueChanged = true;
        }

        public string LabelText
        {
            get { return labelText; }
            set
            {
                labelText = value;
                UpdateEditText();
            }
        }

        protected override void UpdateEditText()
        {
            if(!valueChanged)
            {
                string valueString = Text.Replace(labelText, "").Trim();
                decimal value;

                if (decimal.TryParse(valueString, out value))
                {
                    if (value < Minimum)
                        Value = Minimum;
                    else if (value > Maximum)
                        Value = Maximum;
                    else
                        Value = value;
                }
            }

            Text = Value.ToString() + " " + labelText;
            valueChanged = false;
        }
    }
}
