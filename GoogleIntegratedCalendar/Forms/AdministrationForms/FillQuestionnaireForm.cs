using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Classes;
using EZKO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Model;
using EZKO.UserControls.FlatControls;

namespace EZKO.Forms.AdministrationForms
{
    public partial class FillQuestionnaireForm : System.Windows.Forms.Form
    {
        private EzkoController ezkoController;
        private DatabaseCommunicator.Model.Form form;

        #region Private properties
        private Patient patient { get { return autoCompleteTextBox.Tag as Patient; } }
        #endregion

        public FillQuestionnaireForm(DatabaseCommunicator.Model.Form form)
        {
            InitializeComponent();

            this.form = form;
            ezkoController = GlobalSettings.EzkoController;
            autoCompleteTextBox.Values = ezkoController.GetPatients().ToArray();

            formTitleLabel.Text = form.Name;

            FormGenerator.GenerateForm(flowLayoutPanel, form);
        }

        #region Private methods
        private void FillForm()
        {
            try
            {
                if(ValidateData())
                {
                    SaveQuestionnaire();
                }
                else
                    DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if(patient == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte si vybrať pacienta");
                    autoCompleteTextBox.Focus();
                    result = false;
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        private void SaveQuestionnaire()
        {
            ezkoController.DeleteFilledFields(patient);

            List<FilledField> filledFields = new List<FilledField>();
            try
            {
                foreach (Control item in flowLayoutPanel.Controls)
                {
                    if (item is TextBox textBox && textBox.Text.Trim() != "")
                    {
                        Field field = textBox.Tag as Field;
                        FieldAnswer answer = new FieldAnswer() { TextValue = textBox.Text.Trim() };
                        FilledField filledField = new FilledField()
                        {
                            Field = field,
                            Patient = patient,
                            FieldAnswer = answer
                        };
                        filledFields.Add(filledField);
                    }
                    else if (item is FlatRichTextBox richTextBox && richTextBox.Text.Trim() != "")
                    {
                        Field field = richTextBox.Tag as Field;
                        FieldAnswer answer = new FieldAnswer() { TextValue = richTextBox.Text.Trim() };
                        FilledField filledField = new FilledField()
                        {
                            Field = field,
                            Patient = patient,
                            FieldAnswer = answer
                        };
                        filledFields.Add(filledField);
                    }
                    else if (item is RadioButton radioButton)
                    {
                        if (!radioButton.Checked)
                            continue;

                        FieldValue fieldValue = radioButton.Tag as FieldValue;
                        FilledField filledField = filledFields.FirstOrDefault(x => x.Field.ID == fieldValue.Field.ID);
                        FieldValueAnswer answer = new FieldValueAnswer() { FieldValue = fieldValue, IsChecked = radioButton.Checked };

                        if (filledField != null)
                            filledField.FieldValueAnswers.Add(answer);
                        else
                        {
                            filledField = new FilledField()
                            {
                                Field = fieldValue.Field,
                                Patient = patient,
                            };
                            filledField.FieldValueAnswers.Add(answer);
                            filledFields.Add(filledField);
                        }
                    }
                    else if (item is CheckBox checkBox)
                    {
                        if (!checkBox.Checked)
                            continue;

                        FieldValue fieldValue = checkBox.Tag as FieldValue;
                        FilledField filledField = filledFields.FirstOrDefault(x => x.Field.ID == fieldValue.Field.ID);
                        FieldValueAnswer answer = new FieldValueAnswer() { FieldValue = fieldValue, IsChecked = checkBox.Checked };

                        if (filledField != null)
                            filledField.FieldValueAnswers.Add(answer);
                        else
                        {
                            filledField = new FilledField()
                            {
                                Field = fieldValue.Field,
                                Patient = patient,
                            };
                            filledField.FieldValueAnswers.Add(answer);
                            filledFields.Add(filledField);
                        }
                    }
                    else if (item is ComboBox comboBox)
                    {
                        FieldValue fieldValue = comboBox.SelectedItem as FieldValue;
                        if (fieldValue != null)
                        {
                            FilledField filledField = filledFields.FirstOrDefault(x => x.Field.ID == fieldValue.Field.ID);
                            FieldValueAnswer answer = new FieldValueAnswer() { FieldValue = fieldValue, IsChecked = true };

                            if (filledField != null)
                                filledField.FieldValueAnswers.Add(answer);
                            else
                            {
                                filledField = new FilledField()
                                {
                                    Field = fieldValue.Field,
                                    Patient = patient,
                                };
                                filledField.FieldValueAnswers.Add(answer);
                                filledFields.Add(filledField);
                            }
                        }
                    }
                }

                if (!ezkoController.CreateFilledFields(filledFields))
                    BasicMessagesHandler.ShowErrorMessage("Počas ukladania dotazníka sa vyskytla chyba!");
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas ukladania dotazníka sa vyskytla chyba!", ex);
            }
        }
        #endregion

        #region MainPannelDragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topMenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region HandleCloseButtonEvents
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            closeFormPictureBox.Image = Properties.Resources.closeForm_active_32;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            closeFormPictureBox.Image = Properties.Resources.closeForm_32;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region HandleMaximizeButtonEvents
        private void maximizeFormPictureBox_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_32;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_32;
            }
        }

        private void maximizeFormPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_active_32;
            else
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_active_32;
        }

        private void maximizeFormPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_32;
            else
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_32;
        }
        #endregion

        #region HandleMinimizeButtonEvents
        private void minimizeFormPictureBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void minimizeFormPictureBox_MouseEnter(object sender, EventArgs e)
        {
            minimizeFormPictureBox.Image = Properties.Resources.toTaskbar_active_32;
        }

        private void minimizeFormPictureBox_MouseLeave(object sender, EventArgs e)
        {
            minimizeFormPictureBox.Image = Properties.Resources.toTaskbar_32;
        }
        #endregion

        #region UI Events
        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control item in flowLayoutPanel.Controls)
            {
                item.Width = flowLayoutPanel.Width - FormGenerator.Value;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FillForm();
        }
        #endregion
    }
}
