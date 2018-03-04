using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Model;
using DatabaseCommunicator.Enums;
using EZKO.UserControls.FlatControls;
using System.Drawing;

namespace EZKO.Classes
{
    public static class FormGenerator
    {
        public static int Value = 30;
        private static int patientID;
        private static int userID;

        public static void GenerateForm(FlowLayoutPanel flowPanel, DatabaseCommunicator.Model.Form form)
        {
            //AddSectionLabel(flowPanel, form.Name);

            foreach (var item in form.FieldForms.Where(x => !x.Field.IsDeleted).OrderBy(x => x.Question.Index))
            {
                AddSplitter(flowPanel);
                AddFieldLabel(flowPanel, item.Question.Value);
                AddSplitter(flowPanel);

                switch (item.Field.TypeID)
                {
                    case (int)FieldTypeEnum.Text:
                        AddTextBox(flowPanel, item.Field, null);
                        break;
                    case (int)FieldTypeEnum.LongText:
                        AddLongTextBox(flowPanel, item.Field, null);
                        break;
                    case (int)FieldTypeEnum.RadioBox:
                        AddRadioButtons(flowPanel, item.Field.FieldValues, null);
                        break;
                    case (int)FieldTypeEnum.CheckBox:
                        AddCheckBoxes(flowPanel, item.Field.FieldValues, null);
                        break;
                    case (int)FieldTypeEnum.SelectBox:
                        AddComboBox(flowPanel, item.Field.FieldValues, null);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void GenerateOverview(int patientID, int userID, FlowLayoutPanel flowPanel1, FlowLayoutPanel flowPanel2, List<Field> fields)
        {
            FormGenerator.patientID = patientID;
            FormGenerator.userID = userID;

            if (fields.Count <= 0)
                return;

            int lastSectionID = -1;

            foreach (var field in fields.OrderBy(x => x.SectionID))
            {
                if(lastSectionID != field.SectionID)
                {
                    AddSectionLabel(flowPanel1, field.Section.Name);
                    AddSectionLabel(flowPanel2, field.Section.Name);
                    lastSectionID = field.SectionID;
                }

                AddFieldLabel(flowPanel1, field.Name);
                AddFieldLabel(flowPanel2, field.Name);

                switch (field.TypeID)
                {
                    case (int)FieldTypeEnum.Text:
                        AddTextBox(flowPanel1, field, true);
                        AddTextBox(flowPanel2, field, false);
                        break;
                    case (int)FieldTypeEnum.LongText:
                        AddLongTextBox(flowPanel1, field, true);
                        AddLongTextBox(flowPanel2, field, false);
                        break;
                    case (int)FieldTypeEnum.RadioBox:
                        AddRadioButtons(flowPanel1, field.FieldValues, true);
                        AddRadioButtons(flowPanel2, field.FieldValues, false);
                        break;
                    case (int)FieldTypeEnum.CheckBox:
                        AddCheckBoxes(flowPanel1, field.FieldValues, true);
                        AddCheckBoxes(flowPanel2, field.FieldValues, false);
                        break;
                    case (int)FieldTypeEnum.SelectBox:
                        AddComboBox(flowPanel1, field.FieldValues, true);
                        AddComboBox(flowPanel2, field.FieldValues, false);
                        break;
                    default:
                        break;
                }
            }

            foreach (Control item in flowPanel2.Controls)
            {
                if(item is TextBox)
                    item.Enabled = false;
                else if (item is FlatRichTextBox)
                    item.Enabled = false;
                else if (item is ComboBox)
                    item.Enabled = false;
                else if (item is RadioButton)
                    item.Enabled = false;
                else if (item is CheckBox)
                    item.Enabled = false;
            }
        }

        private static void AddSplitter(FlowLayoutPanel flowPanel)
        {
            Panel splitter = new Panel() { Height = 2, Width = flowPanel.Width - Value, BackColor = Color.Gray};
            flowPanel.Controls.Add(splitter);
        }

        private static void AddSectionLabel(FlowLayoutPanel flowPanel, string text)
        {
            Label label = new Label()
            {
                Text = text,
                AutoSize = true
            };
            label.Font = new System.Drawing.Font(label.Font.FontFamily, 15, System.Drawing.FontStyle.Bold);
            flowPanel.Controls.Add(label);
            AddSplitter(flowPanel);
        }

        private static void AddFieldLabel(FlowLayoutPanel flowPanel, string text)
        {
            Label label = new Label() { Text = text, AutoSize = true };
            label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size, System.Drawing.FontStyle.Bold);
            flowPanel.Controls.Add(label);
        }

        private static void AddTextBox(FlowLayoutPanel flowPanel, Field field, bool? doctorsSide)
        {
            FilledField filledField = GetFilledField(field, doctorsSide);

            TextBox textBox = new TextBox() { Width = flowPanel.Width - Value, AutoSize = true, Tag = field};

            if (filledField != null)
                textBox.Text = filledField.FieldAnswer.TextValue;

            flowPanel.Controls.Add(textBox);
        }

        private static void AddLongTextBox(FlowLayoutPanel flowPanel, Field field, bool? doctorsSide)
        {
            FilledField filledField = GetFilledField(field, doctorsSide);

            FlatRichTextBox textBox = new FlatRichTextBox() { Width = flowPanel.Width - Value, AutoSize = true, Tag = field};

            if (filledField != null)
                textBox.Text = filledField.FieldAnswer.TextValue;

            flowPanel.Controls.Add(textBox);
        }

        private static void AddRadioButtons(FlowLayoutPanel flowPanel, ICollection<FieldValue> fieldValues, bool? doctorsSide)
        {
            if (fieldValues.Count <= 0)
                return;

            FilledField filledField = GetFilledField(fieldValues.First().Field, doctorsSide);

            foreach (var value in fieldValues)
            {
                bool answer = false;
                if (filledField != null)
                {
                    FieldValueAnswer valueAnswer = filledField.FieldValueAnswers?.FirstOrDefault(x => x.FieldValueID == value.ID);
                    if (valueAnswer != null)
                        answer = valueAnswer.IsChecked;
                }

                RadioButton radioButton = new RadioButton() { Checked = answer, Text = value.Value, AutoSize = true, Tag = value };
                flowPanel.Controls.Add(radioButton);
            }
        }

        private static void AddCheckBoxes(FlowLayoutPanel flowPanel, ICollection<FieldValue> fieldValues, bool? doctorsSide)
        {
            if (fieldValues.Count <= 0)
                return;

            FilledField filledField = GetFilledField(fieldValues.First().Field, doctorsSide);

            foreach (var value in fieldValues)
            {
                bool answer = false;
                if(filledField != null)
                {
                    FieldValueAnswer valueAnswer = filledField.FieldValueAnswers.FirstOrDefault(x => x.FieldValueID == value.ID);
                    if (valueAnswer != null)
                        answer = valueAnswer.IsChecked;
                }

                CheckBox checkBox = new CheckBox() { Checked = answer, Text = value.Value, AutoSize = true, Tag = value};
                flowPanel.Controls.Add(checkBox);
            }
        }

        private static void AddComboBox(FlowLayoutPanel flowPanel, ICollection<FieldValue> fieldValues, bool? doctorsSide)
        {
            if (fieldValues.Count <= 0)
                return;
            FilledField filledField = GetFilledField(fieldValues.First().Field, doctorsSide);

            ComboBox comboBox = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList, Width = flowPanel.Width - Value};
            foreach (var value in fieldValues)
            {
                int index = comboBox.Items.Add(value);

                if (filledField != null)
                {
                    FieldValueAnswer valueAnswer = filledField.FieldValueAnswers.FirstOrDefault(x => x.FieldValueID == value.ID);
                    if (valueAnswer != null)
                        comboBox.SelectedIndex = index;
                }
            }
            flowPanel.Controls.Add(comboBox);
        }

        private static FilledField GetFilledField(Field field, bool? doctorsSide = null)
        {
            if (!doctorsSide.HasValue)
                return null;

            if(doctorsSide.Value)
            {
                return field.FilledFields.FirstOrDefault(x => x.FieldID == field.ID &&
                 x.PatientID == patientID && x.UserID == userID);
            }
            else
            {
                return field.FilledFields.FirstOrDefault(x => x.FieldID == field.ID &&
                 x.PatientID == patientID && x.UserID == null);
            }
        }
    }
}
