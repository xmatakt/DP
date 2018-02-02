using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Classes;
using EZKO.Controllers;
using EZKO.Enums;
using EZKO.UserControls.FlatControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.Forms.AdministrationForms
{
    public partial class EditPatientForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private Patient patient;

        #region Private properties
        #region Personal info tab

        private string avatarImagePath_ = null;
        private string avatarImagePath
        {
            get{ return avatarImagePath_; }
            set
            {
                avatarPictureBox.Image = DirectoriesController.GetImage(value, Properties.Resources.noUserImage_white);
                avatarImagePath_ = value;
            }
        }
        string name
        {
            get
            {
                string val = nameTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { nameTextBox.Text = value; }
        }

        string surname
        {
            get
            {
                string val = surnameTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { surnameTextBox.Text = value; }
        }

        DateTime? birthDate
        {
            get
            {
                if (birthDatePicker.Value != new DateTime(1800, 1, 1))
                    return birthDatePicker.Value;
                else
                    return null;
            }
            set
            {
                if (value.HasValue)
                {
                    birthDatePicker.Format = DateTimePickerFormat.Custom;
                    birthDatePicker.CustomFormat = "dd.MM.yyyy";
                    birthDatePicker.Value = value.Value;
                }
                else
                {
                    birthDatePicker.Format = DateTimePickerFormat.Custom;
                    birthDatePicker.CustomFormat = " ";
                    birthDatePicker.Value = new DateTime(1800, 1, 1);
                }
            }
        }

        string BIFO
        {
            get
            {
                string val = bifoTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { bifoTextBox.Text = value ?? ""; }
        }

        string legalRepresentative
        {
            get
            {
                string val = representativeTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { representativeTextBox.Text = value ?? ""; }
        }

        string titleBefore
        {
            get
            {
                string val = firstTitleTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { firstTitleTextBox.Text = value ?? ""; }
        }

        string titleAfter
        {
            get
            {
                string val = secondTitleTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { secondTitleTextBox.Text = value ?? ""; }
        }

        string birthNumber
        {
            get
            {
                string val = birthNumberTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { birthNumberTextBox.Text = value ?? ""; }
        }

        InsuranceCompany insuranceCompany
        {
            get { return insuranceCompanyComboBox.SelectedItem as InsuranceCompany; }
            set
            {
                if (value == null)
                    insuranceCompanyComboBox.SelectedIndex = 0;
                else
                    insuranceCompanyComboBox.SelectedItem = value;
            }
        }

        SexEnum sex
        {
            get
            {
                if (manRadioButton.Checked)
                    return SexEnum.Man;
                else if (womanRadioButton.Checked)
                    return SexEnum.Woman;
                else
                    return SexEnum.Unknown;
            }
            set
            {
                //sex = value;
                switch (value)
                {
                    case SexEnum.Woman:
                        womanRadioButton.Checked = true;
                        break;
                    case SexEnum.Man:
                        manRadioButton.Checked = true;
                        break;
                    case SexEnum.Unknown:
                        manRadioButton.Checked = false;
                        womanRadioButton.Checked = false;
                        break;
                    default:
                        break;
                }
            }
        }

        string street
        {
            get
            {
                string val = streetTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { streetTextBox.Text = value ?? ""; }
        }

        string streetNumber
        {
            get
            {
                string val = streetNumberTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { streetNumberTextBox.Text = value ?? ""; }
        }

        string city
        {
            get
            {
                string val = cityTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { cityTextBox.Text = value ?? ""; }
        }

        string zip
        {
            get
            {
                string val = zipTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { zipTextBox.Text = value ?? ""; }
        }

        string country
        {
            get
            {
                string val = countryTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { countryTextBox.Text = value ?? ""; }
        }

        string email
        {
            get
            {
                return emailTextBox.Text.Trim();
            }
            set { emailTextBox.Text = value ?? ""; }
        }

        string alternativeEmail
        {
            get
            {
                string val = alternativeEmailTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { alternativeEmailTextBox.Text = value ?? ""; }
        }

        string phone
        {
            get
            {
                return phoneTextBox.Text.Trim();
            }
            set { phoneTextBox.Text = value ?? ""; }
        }

        string alternativePhone
        {
            get
            {
                string val = alternativePhoneTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { alternativePhoneTextBox.Text = value ?? ""; }
        }

        string facebook
        {
            get
            {
                string val = fbTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { fbTextBox.Text = value ?? ""; }
        }

        string employment
        {
            get
            {
                string val = employmentRichTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { employmentRichTextBox.Text = value ?? ""; }
        }

        string note
        {
            get
            {
                string val = noteRichTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { noteRichTextBox.Text = value ?? ""; }
        }
        #endregion
        #endregion

        public EditPatientForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            this.ezkoController = GlobalSettings.EzkoController;
            this.workingType = workingType;
        }

        public EditPatientForm(Patient patient)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.patient = patient;

            InitializeForm();
        }

        #region Private methods
        private void InitializeForm()
        {
            try
            {
                InitializeInsuranceCompanies();
                InitializePersonalInfoTab();
                InitializeTreeViewTab();
                InitializeTextDocumentationTab();
            }
            catch(Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas načítavania údajov o pacientovi sa vyskytla chyba", ex);
            }
        }

        private void InitializeInsuranceCompanies()
        {
            insuranceCompanyComboBox.Items.Add("[ Vybrať ]");
            foreach (var item in ezkoController.GetInsuranceCompanies())
                insuranceCompanyComboBox.Items.Add(item);

            insuranceCompanyComboBox.SelectedIndex = 0;
        }

        private void InitializePersonalInfoTab()
        {
            if(patient != null)
            {
                avatarImagePath = patient.AvatarImagePath;
                idTextBox.Text = patient.ID.ToString();
                name = patient.Name;
                surname = patient.Surname;
                birthDate = patient.BirthDate;
                BIFO = patient.BIFO;
                legalRepresentative = patient.LegalRepresentative;
                titleBefore = patient.TitleBefore;
                titleAfter = patient.TitleAfter;
                birthNumber = patient.BirthNumber;
                insuranceCompany = patient.InsuranceCompany;
                if (patient.SexID == null)
                    sex = SexEnum.Unknown;
                else
                    sex = (patient.SexID == 1) ? SexEnum.Woman : SexEnum.Man;
                street = patient.Address?.Street;
                streetNumber = patient.Address?.StreetNumber;
                city = patient.Address?.City;
                zip = patient.Address?.PostNumber;
                country = patient.Address?.Country;
                phone = patient.Contact.Phone;
                alternativePhone = patient.Contact.AlternativePhone;
                email = patient.Contact.Email;
                alternativeEmail = patient.Contact.AlternativeEmail;
                facebook = patient.Contact.Facebook;
                employment = patient.Employment;
                note = patient.Note;
            }
        }

        private void InitializeTreeViewTab()
        {
            if(patient != null && patient.RootDirectoryPath != null)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(patient.RootDirectoryPath);
                BuildTree(directoryInfo, treeView.Nodes);
            }
        }

        private void InitializeTextDocumentationTab()
        {
            FormGenerator.GenerateOverview(patient.ID, GlobalSettings.User.ID, doctorsFlowPanel, patientsFlowPanel, ezkoController.GetFields().ToList());
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.FullName, directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if (name == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať meno pacienta");
                    nameTextBox.Focus();
                    result = false;
                }
                else if (surname == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať priezvisko pacienta");
                    surnameTextBox.Focus();
                    result = false;
                }
                else if (BIFO != null && BIFO.Length != 10)
                {
                    BasicMessagesHandler.ShowInformationMessage("BIFO musí byť 10 znakový kód");
                    bifoTextBox.Focus();
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

        private void UpdateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    string fileName = System.IO.Path.GetFileName(avatarImagePath);
                    string patientAvatarImagePath = DirectoriesController.GetPatientImageFolder(patient) + @"\" + fileName;

                    if (!ezkoController.EditPatient(patient, name, surname, birthDate, BIFO, legalRepresentative, titleBefore, titleAfter, birthNumber,
                        insuranceCompany, sex, street, streetNumber, city, zip, country, phone, alternativePhone, email, alternativeEmail,
                        facebook, employment, note, patientAvatarImagePath))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy pacienta sa vyskytla chyba");
                    else
                    {
                        SaveFieldsOverview();
                        if (avatarImagePath != null)
                        {
                            // iba docasne!!
                            DirectoriesController.CreatePatientFolderStructure(patient);
                            //
                            DirectoriesController.CopyFile(avatarImagePath, patientAvatarImagePath);
                        }
                    }
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

        private void SaveFieldsOverview()
        {
            ezkoController.DeleteFilledFields(patient, GlobalSettings.User);

            List<FilledField> filledFields = new List<FilledField>();
            try
            {
                foreach (Control item in doctorsFlowPanel.Controls)
                {
                    if (item is TextBox textBox && textBox.Text.Trim() != "")
                    {
                        Field field = textBox.Tag as Field;
                        FieldAnswer answer = new FieldAnswer() { TextValue = textBox.Text.Trim() };
                        FilledField filledField = new FilledField()
                        {
                            Field = field,
                            Patient = patient,
                            User = GlobalSettings.User,
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
                            User = GlobalSettings.User,
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
                                User = GlobalSettings.User,
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
                                User = GlobalSettings.User,
                            };
                            filledField.FieldValueAnswers.Add(answer);
                            filledFields.Add(filledField);
                        }
                    }
                    else if (item is ComboBox comboBox)
                    {
                        FieldValue fieldValue = comboBox.SelectedItem as FieldValue;
                        if(fieldValue != null)
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
                                    User = GlobalSettings.User,
                                };
                                filledField.FieldValueAnswers.Add(answer);
                                filledFields.Add(filledField);
                            }
                        }
                    }
                }

                if(!ezkoController.CreateFilledFields(filledFields))
                    BasicMessagesHandler.ShowErrorMessage("Počas ukladania zmien vo vyplnení EZKO polí sa vyskytla chyba!");
            }
            catch(Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas ukladania zmien vo vyplnení EZKO polí sa vyskytla chyba!", ex);
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
        private void changeAvatarButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                avatarImagePath = openFileDialog.FileName;
        }

        private void EditPatientForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
            surnameTextBox.MaxLength = 30;
            birthDatePicker.MaxDate = DateTime.Now;
            bifoTextBox.MaxLength = 10;
            representativeTextBox.MaxLength = 80;
            firstTitleTextBox.MaxLength = 20;
            secondTitleTextBox.MaxLength = 20;
            birthNumberTextBox.MaxLength = 11;
            streetTextBox.MaxLength = 80;
            streetNumberTextBox.MaxLength = 20;
            cityTextBox.MaxLength = 40;
            zipTextBox.MaxLength = 10;
            countryTextBox.MaxLength = 40;
            emailTextBox.MaxLength = 80;
            alternativeEmailTextBox.MaxLength = 80;
            phoneTextBox.MaxLength = 20;
            alternativePhoneTextBox.MaxLength = 20;
            fbTextBox.MaxLength = 80;
            idTextBox.TextAlign = HorizontalAlignment.Right;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
        }

        private void birthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if(birthDatePicker.Value > new DateTime(1800, 1, 1))
            {
                birthDatePicker.Format = DateTimePickerFormat.Custom;
                birthDatePicker.CustomFormat = "dd.MM.yyyy";
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void generatePdfButton_Click(object sender, EventArgs e)
        {
            BasicMessagesHandler.ShowInformationMessage("Timo dorob to!");
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Node.Name);
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa neznáma chyba!", ex);
            }
        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            patientsFlowPanel.VerticalScroll.Value = doctorsFlowPanel.VerticalScroll.Value;
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;

            if (panel != null)
            {
                foreach (Control item in panel.Controls)
                {
                    item.Width = panel.Width - FormGenerator.Value;
                }
            }
        }
        #endregion
    }
}
