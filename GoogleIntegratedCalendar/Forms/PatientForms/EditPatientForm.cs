using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Controllers;
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

namespace EZKO.Forms.AdministrationForms
{
    public partial class EditPatientForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private WorkingInfoForm workingInfoForm;
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
                string val = emailTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
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
                string val = phoneTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
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

        private void CreateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {

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
                    string fileName = System.IO.Path.GetFileName(avatarImagePath);
                    string patientAvatarImagePath = DirectoriesController.GetPatientImageFolder(patient) + @"\" + fileName;

                    if (!ezkoController.EditPatient(patient, name, surname, birthDate, BIFO, legalRepresentative, titleBefore, titleAfter, birthNumber,
                        insuranceCompany, sex, street, streetNumber, city, zip, country, phone, alternativePhone, email, alternativeEmail,
                        facebook, employment, note, patientAvatarImagePath))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy pacienta sa vyskytla chyba");
                    else
                    {
                        if(avatarImagePath != null)
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

        #region BG worker
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (workingInfoForm != null)
                workingInfoForm.Close();
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
            CreateOrUpdate();
        }

        private void generatePdfButton_Click(object sender, EventArgs e)
        {
            BasicMessagesHandler.ShowInformationMessage("Timo dorob to!");
        }
        #endregion
    }
}
