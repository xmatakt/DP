using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using DatabaseCommunicator.Model;
using DatabaseCommunicator.Enums;
using EZKO.Controllers;

namespace EZKO.Forms.PatientForms
{
    public partial class NewPatientForm : System.Windows.Forms.Form
    {
        private EzkoController ezkoController;

        #region Private properties
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
            set { bifoTextBox.Text = value; }
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
            set { representativeTextBox.Text = value; }
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
            set { firstTitleTextBox.Text = value; }
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
            set { secondTitleTextBox.Text = value; }
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
            set { birthNumberTextBox.Text = value; }
        }

        InsuranceCompany insuranceCompany
        {
            get{ return insuranceCompanyComboBox.SelectedItem as InsuranceCompany; }
        }

        SexEnum sex
        {
            get
            {
                if (manRadioButton.Checked)
                    return SexEnum.Man;
                else
                    return SexEnum.Woman;
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
            set { streetTextBox.Text = value; }
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
            set { streetNumberTextBox.Text = value; }
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
            set { cityTextBox.Text = value; }
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
            set { zipTextBox.Text = value; }
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
            set { countryTextBox.Text = value; }
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
            set { emailTextBox.Text = value; }
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
            set { phoneTextBox.Text = value; }
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
        }
        #endregion

        public NewPatientForm()
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            InitializeInsuranceCompaniesComboBox();
        }

        #region Private methods

        private void InitializeInsuranceCompaniesComboBox()
        {
            insuranceCompanyComboBox.Items.Add("[Vybrať]");
            foreach (var item in ezkoController.GetInsuranceCompanies())
                insuranceCompanyComboBox.Items.Add(item);

            if (insuranceCompanyComboBox.Items.Count > 0)
                insuranceCompanyComboBox.SelectedIndex = 0;
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if(name == null)
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
                else if(BIFO != null && BIFO.Length != 10)
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
                    Address address = ezkoController.CreateAddress(street, streetNumber, city, zip, country);
                    Contact contact = ezkoController.CreateContact(email, phone);
                    if(contact != null)
                    {
                        Patient patient = ezkoController.CreatePatient(name, surname, birthDate, BIFO, legalRepresentative,
                        titleBefore, titleAfter, birthNumber, insuranceCompany, sex, address, contact);
                        if(patient != null)
                        {
                            if (DirectoriesController.CreatePatientFolderStructure(patient))
                            {
                                string rootFolderPath = DirectoriesController.GetPatientRootFolder(patient);
                                patient.RootDirectoryPath = rootFolderPath;
                                if (!ezkoController.SaveChanges())
                                    BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa uložiť cestu ku koreňoveému adresáru pacienta.");
                            }
                            else
                                BasicMessagesHandler.ShowErrorMessage("Nepodarilo vytvoriť adresárovú štruktúru pre nového pacienta.");
                        }
                        else
                            BasicMessagesHandler.ShowErrorMessage("Pacienta sa nepodarilo vytvoriť.");
                    }
                    else
                        BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť pacienta. Nastala chyba pri vytvorení kontaktu.");
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
        private void NewPatientForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
            surnameTextBox.MaxLength = 30;
            birthDatePicker.MaxDate = DateTime.Now;
            birthDatePicker.Value = new DateTime(1800, 1, 1);
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
            phoneTextBox.MaxLength = 20;

            manRadioButton.Checked = true;
            //birthDatePicker.Format = DateTimePickerFormat.Custom;
            //birthDatePicker.CustomFormat = "dd.MM.yyyy";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateData();
        }
        #endregion
    }
}
