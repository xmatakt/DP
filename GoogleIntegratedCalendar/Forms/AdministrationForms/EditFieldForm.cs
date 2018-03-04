using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Enums;
using EZKO.UserControls.FlatControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.Forms.AdministrationForms
{
    public partial class EditFieldForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private Field field;

        #region Private properties
        private string name
        {
            get
            {
                string val = nameTextBox.Text.Trim();
                if (val.Length < 1)
                    val = null;

                return val;
            }
            set { nameTextBox.Text = value; }
        }

        private string standardNumber
        {
            get
            {
                string val = standardNumberTextBox.Text.Trim();
                if (val.Length < 1)
                    val = null;

                return val;
            }
            set { standardNumberTextBox.Text = value; }
        }

        private string otherName
        {
            get
            {
                string val = snomedTextBox.Text.Trim();
                if (val.Length < 1)
                    val = null;

                return val;
            }
            set { snomedTextBox.Text = value; }
        }

        private FieldType fieldType
        {
            get { return fieldTypeComboBox.SelectedItem as FieldType; }
            set { fieldTypeComboBox.SelectedItem = value; }
        }

        private Section section
        {
            get { return sectionComboBox.SelectedItem as Section; }
            set { sectionComboBox.SelectedItem = value; }
        }

        private string description
        {
            get
            {
                string val = descriptionRichTextBox.Text.Trim();
                if (val.Length < 1)
                    val = null;

                return val;
            }
            set { descriptionRichTextBox.Text = value; }
        }

        private List<FieldForm> affectedFormulars
        {
            get
            {
                List<FieldForm> result = new List<FieldForm>();
                Control[] controls = formularsTablePanel.Controls.Find("checkBox", true);

                foreach (var item in controls)
                {
                    if (item is CheckBox checkBox)
                    {
                        if(checkBox.Checked)
                        {
                            if (checkBox.Tag is DatabaseCommunicator.Model.Form form)
                            {
                                Control textBoxControl = formularsTablePanel.Controls.Find(form.ID.ToString(), true).FirstOrDefault();

                                if(textBoxControl != null && textBoxControl is TextBox textBox)
                                {
                                    if(textBox.Text.Trim().Length == 0)
                                    {
                                        textBox.Focus();
                                        BasicMessagesHandler.ShowInformationMessage("Musíte zadať otázku do formulára");
                                        result = null;
                                        break;
                                    }
                                    else
                                    {
                                        Question question = new Question()
                                        {
                                            Value = textBox.Text.Trim(),
                                        };

                                        FieldForm fieldForm = new FieldForm()
                                        {
                                            Form = form,
                                            Question = question
                                        };

                                        result.Add(fieldForm);
                                    }
                                }
                            }
                        }
                    }
                }

                return result;
            }
        }

        private List<FieldValue> fieldValues
        {
            get
            {
                try
                {
                    List<FieldValue> result = new List<FieldValue>();

                    foreach(string value in valuesTextBox.Text.Trim().Split(new[] { ',' }).Select(x => x.Trim()))
                    {
                        if(value.Trim().Length > 0)
                        {
                            FieldValue fieldValue = new FieldValue()
                            {
                                Value = value.Trim(),
                                IsDeleted = false
                            };
                            result.Add(fieldValue);
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            set
            {
                bool isFirst = true;
                foreach(var val in value)
                {
                    if (isFirst)
                    {
                        valuesTextBox.Text += val.Value;
                        isFirst = false;
                    }
                    else
                        valuesTextBox.Text += ", " + val.Value;
                }

                UpdateInsightPanel();
            }
        }
        #endregion

        public EditFieldForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = workingType;

            InitializeForm();
        }

        public EditFieldForm(Field field)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.field = field;
            addButton.Text = "Upraviť pole EZKO";

            InitializeForm();
        }

        #region Private methods
        private void InitializeForm()
        {
            InitializeFieldTypeComboBox();
            InitializeSectionsComboBox();
            InitializeFormularsTablePanel();

            if (fieldType != null)
            {
                switch (fieldType.ID)
                {
                    case (int)FieldTypeEnum.Text:
                    case (int)FieldTypeEnum.LongText:
                        SetValuesElementsVisibility(false);
                        break;
                    default:
                        SetValuesElementsVisibility(true);
                        break;
                }
            }

            if(field != null)
            {
                name = field.Name;
                standardNumber = field.StandardNumber;
                otherName = field.OtherName;
                fieldType = field.FieldType;
                section = field.Section;
                description = field.Description;

                fieldValues = field.FieldValues.ToList();
            }
        }

        private void InitializeFieldTypeComboBox()
        {
            foreach (var item in ezkoController.GetFieldTypes())
                fieldTypeComboBox.Items.Add(item);

            if (fieldTypeComboBox.Items.Count > 0)
                fieldTypeComboBox.SelectedIndex = 0;
        }

        private void InitializeSectionsComboBox()
        {
            foreach (var item in ezkoController.GetSections())
                sectionComboBox.Items.Add(item);

            if (sectionComboBox.Items.Count > 0)
                sectionComboBox.SelectedIndex = 0;
        }

        private void InitializeFormularsTablePanel()
        {
            foreach (var formular in ezkoController.GetFormulars())
            {
                var checkBox = new CheckBox()
                {
                    Name = "checkBox",
                    Text = formular.Name,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = formular,
                };

                var textBox = new TextBox()
                {
                    Name = formular.ID.ToString(),
                    Dock = DockStyle.Fill,
                    Height = 22,
                };

                if(field != null)
                {
                    FieldForm fieldForm = field.FieldForms.FirstOrDefault(x => x.FormID == formular.ID);
                    if(fieldForm != null)
                    {
                        checkBox.Checked = true;
                        textBox.Text = fieldForm.Question.Value;
                    }
                }

                int lastRowIndex = formularsTablePanel.RowCount;
                formularsTablePanel.Controls.Add(checkBox, 0, lastRowIndex);
                formularsTablePanel.Controls.Add(textBox, 1, lastRowIndex);
                formularsTablePanel.RowCount++;
            }
        }

        private void SetValuesElementsVisibility(bool value)
        {
            valuesLabel.Visible = value;
            valuesTextBox.Visible = value;
            valuesInfolabel.Visible = value;
        }

        private void UpdateInsightPanel()
        {
            if (fieldType != null)
            {
                insightFlowPanel.Controls.Clear();
                int width = insightFlowPanel.Width - 7;
                Control newControl = null;

                switch (fieldType.ID)
                {
                    case (int)FieldTypeEnum.Text:
                        newControl = new TextBox() { Width = width };
                        insightFlowPanel.Controls.Add(newControl);
                        break;

                    case (int)FieldTypeEnum.LongText:
                        newControl = new FlatRichTextBox() { Width = width, Height = 100 };
                        insightFlowPanel.Controls.Add(newControl);
                        break;

                    case (int)FieldTypeEnum.RadioBox:
                        List<FieldValue> values = fieldValues;
                        if (values != null)
                        {
                            foreach (var value in values)
                            {
                                newControl = new RadioButton() { Width = width, Checked = false, Text = value.Value };
                                insightFlowPanel.Controls.Add(newControl);
                            }
                        }
                        break;

                    case (int)FieldTypeEnum.SelectBox:
                        values = fieldValues;
                        if (values != null)
                        {
                            ComboBox comboBox = new ComboBox() { Width = width, DropDownStyle = ComboBoxStyle.DropDownList };
                            foreach (var value in values)
                            {
                                comboBox.Items.Add(value);
                            }
                            insightFlowPanel.Controls.Add(comboBox);

                            if (comboBox.Items.Count > 0)
                                comboBox.SelectedIndex = 0;
                        }
                        break;

                    case (int)FieldTypeEnum.CheckBox:
                        values = fieldValues;
                        if (values != null)
                        {
                            foreach (var value in values)
                            {
                                newControl = new CheckBox() { Width = width, Checked = false, Text = value.Value };
                                insightFlowPanel.Controls.Add(newControl);
                            }
                        }
                        break;
                }
            }
        }

        private void CreateOrUpdate()
        {
            switch (workingType)
            {
                case WorkingTypeEnum.Creating:
                    CreateData();
                    break;
                case WorkingTypeEnum.Editing:
                    UpdateData();
                    break;
                default:
                    break;
            }
        }
        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if(name == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať názov poľa EZKO");
                    nameTextBox.Focus();
                    result = false;
                }
                else if (fieldType == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte si zvoliť typ poľa EZKO");
                    fieldTypeComboBox.Focus();
                    result = false;
                }
                else if (section == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte si zvoliť sekciu pre pole EZKO");
                    sectionComboBox.Focus();
                    result = false;
                }
                else if(affectedFormulars == null)
                {
                    result = false;
                }
                else if(fieldValues != null && fieldValues.Count == 0)
                {
                    if(fieldType.ID != (int)FieldTypeEnum.Text && fieldType.ID != (int)FieldTypeEnum.LongText)
                    {
                        BasicMessagesHandler.ShowInformationMessage("Musíte zadať aspoň jednu hodnotu");
                        valuesTextBox.Focus();
                        result = false;
                    }
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        private void CreateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    if (ezkoController.CreateField(name, standardNumber, otherName, fieldType, section, description, fieldValues, affectedFormulars))
                        BasicMessagesHandler.ShowInformationMessage("Pole EZKO bolo úspešne vytvorené");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas vytvárania poľa EZKO sa vyskytla chyba");
                }
                else
                    DialogResult = DialogResult.None;
            
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            Cursor = Cursors.Default;
        }

        private void UpdateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    if (!ezkoController.EditField(field, name, standardNumber, otherName, fieldType, section, description, fieldValues, affectedFormulars))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy poľa EZKO sa vyskytla chyba");
                }
                else
                    DialogResult = DialogResult.None;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            Cursor = Cursors.Default;
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
        private void EditFieldForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 255;
            snomedTextBox.MaxLength = 255;
            standardNumberTextBox.MaxLength = 255;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }

        private void fieldTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fieldType != null)
            {
                switch (fieldType.ID)
                {
                    case (int)FieldTypeEnum.Text:
                    case (int)FieldTypeEnum.LongText:
                        SetValuesElementsVisibility(false);
                        break;
                    default:
                        SetValuesElementsVisibility(true);
                        break;
                }

                UpdateInsightPanel();
            }
        }

        private void valuesTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateInsightPanel();
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            insightLabel.Text = nameTextBox.Text.Trim();
        }
        #endregion
    }
}
