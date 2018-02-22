using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using DatabaseCommunicator.Model;

namespace EZKO.Forms.AdministrationForms
{
    /// <summary>
    /// Class which provides functionality to create or edit InsuranceCompany entities
    /// </summary>
    public partial class EditInsuranceCompanyForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private InsuranceCompany insuranceCompany;

        #region Private properties
        private string insuranceCompanyName
        {
            get { return insuranceNameTextBox.Text.Trim(); }
            set { insuranceNameTextBox.Text = value; }
        }

        private string insuranceCompanyCode
        {
            get { return insuranceCodeTextBox.Text.Trim(); }
            set { insuranceCodeTextBox.Text = value; }
        }
        #endregion

        //Just for testing purpose
        //public EditInsuranceCompanyForm(WorkingTypeEnum workingType)
        //{
        //    InitializeComponent();

        //    ezkoController = new EzkoController(GlobalSettings.ConnectionString);
        //    this.workingType = workingType;
        //}

        public EditInsuranceCompanyForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = workingType;
        }

        public EditInsuranceCompanyForm(InsuranceCompany insuranceCompany)
        {
            InitializeComponent();

            this.insuranceCompany = insuranceCompany;
            ezkoController = GlobalSettings.EzkoController;
            workingType = WorkingTypeEnum.Editing;

            addButton.Text = "Upraviť poisťovňu";
            insuranceCompanyName = insuranceCompany.Name;
            insuranceCompanyCode = insuranceCompany.Code;
        }

        #region Private methods
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
                if(insuranceCompanyName.Length < 1)
                {
                    BasicMessagesHandler.ShowInformationMessage("Nezadali ste názov poisťovne");
                    insuranceNameTextBox.Focus();
                    result = false;
                }
                else if(insuranceCompanyCode.Length < 1)
                {
                    BasicMessagesHandler.ShowInformationMessage("Nezadali ste kód poisťovne");
                    insuranceCodeTextBox.Focus();
                    result = false;
                }
                else if (insuranceCompany == null && ezkoController.InsuranceCompanyNameExists(insuranceCompanyName))
                {
                    BasicMessagesHandler.ShowInformationMessage("Zadaný názov poisťovne už existuje");
                    insuranceNameTextBox.Focus();
                    result = false;
                }
                else if (insuranceCompany != null && insuranceCompany.Name != insuranceCompanyName && ezkoController.InsuranceCompanyNameExists(insuranceCompanyName))
                {
                    BasicMessagesHandler.ShowInformationMessage("Zadaný názov poisťovne už existuje");
                    insuranceNameTextBox.Focus();
                    result = false;
                }
                else if (insuranceCompany == null && ezkoController.InsuranceCompanyCodeExists(insuranceCompanyCode))
                {
                    BasicMessagesHandler.ShowInformationMessage("Zadaný kód poisťovne už existuje");
                    insuranceCodeTextBox.Focus();
                    result = false;
                }
                else if (insuranceCompany != null && insuranceCompany.Code != insuranceCompanyCode && ezkoController.InsuranceCompanyCodeExists(insuranceCompanyCode))
                {
                    BasicMessagesHandler.ShowInformationMessage("Zadaný kód poisťovne už existuje");
                    insuranceCodeTextBox.Focus();
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
                    if (ezkoController.CreateInsuranceCompany(insuranceCompanyName, insuranceCompanyCode))
                        BasicMessagesHandler.ShowInformationMessage("Poisťovňa bola úspešne vytvorená");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Pri vytváraní poisťovňe sa vyskytla chyba!");
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
                    if (!ezkoController.EditInsuranceCompany(insuranceCompany, insuranceCompanyName, insuranceCompanyCode))
                        BasicMessagesHandler.ShowErrorMessage("Pri editovaní poisťovňe sa vyskytla chyba!");
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
        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        private void insuranceCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CreateOrUpdate();
        }

        private void EditInsuranceCompanyForm_Load(object sender, EventArgs e)
        {
            insuranceNameTextBox.MaxLength = 30;
            insuranceCodeTextBox.MaxLength = 12;
        }
        #endregion
    }
}
