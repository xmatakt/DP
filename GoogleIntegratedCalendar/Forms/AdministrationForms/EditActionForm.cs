using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using ExceptionHandler;
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
    public partial class EditActionForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private WorkingInfoForm workingInfoForm;

        #region Private properties
        private string actionName
        {
            get { return actionNameTextBox.Text.Trim(); }
        }

        private string shortcut
        {
            get { return actionShortcutTextBox.Text.Trim(); }
        }

        private string longName
        {
            get
            {
                string longActionName = longNameTextBox.Text.Trim();
                if (longActionName.Length == 0)
                    return null;
                else
                    return longActionName;
            }
        }

        private string material
        {
            get
            {
                string trimmedMaterial = materialRichTextBox.Text.Trim();
                if (trimmedMaterial.Length == 0)
                    return null;
                else
                    return trimmedMaterial;
            }
        }

        private int recommendedLength
        {
            get { return (int)recommendedLengthUpDown.Value; }
        }

        private decimal costs
        {
            get { return costsUpDown.Value; }
        }

        private decimal margin
        {
            get { return marginUpDown.Value; }
        }

        private decimal insuranceCompanyMargin
        {
            get { return companyMarginUpDown.Value; }
        }

        private InsuranceCompany insuranceCompany
        {
            get
            {
                if (companyCodeComboBox.SelectedIndex < 0)
                    return null;

                return (InsuranceCompany)companyCodeComboBox.SelectedItem;
            }
        }

        private Field field
        {
            get
            {
                if (ezkoFieldComboBox.SelectedIndex < 0 || ezkoFieldComboBox.SelectedIndex == 0)
                    return null;

                return (Field)ezkoFieldComboBox.SelectedItem;
            }
        }

        private bool hasSpecification
        {
            get { return hasSpecificationCheckBox.Checked; }
        }
        #endregion

        //Just for testing purpose
        public EditActionForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            ezkoController = new EzkoController(GlobalSettings.ConnectionString);
            this.workingType = workingType;

            InitializeForm();
        }

        public EditActionForm(EzkoController ezkoController, WorkingTypeEnum workingType)
        {
            InitializeComponent();

            this.ezkoController = ezkoController;
            this.workingType = workingType;

            InitializeForm();
        }

        #region Private methods
        private void InitializeForm(InsuranceCompany company = null)
        {
            InitializeInsuranceCompaniesComboBox();
            InitializeEZKOFieldsComboBox();
        }

        private void InitializeInsuranceCompaniesComboBox()
        {
            var companies = ezkoController.GetInsuranceCompanies();
            if (companies == null)
                return;

            foreach (var company in companies)
                companyCodeComboBox.Items.Add(company);
        }

        private void InitializeEZKOFieldsComboBox()
        {
            ezkoFieldComboBox.Items.Add("Bez prepojenia na EZKO pole");
            var fields = ezkoController.GetFields();
            if (fields == null)
                return;

            foreach (var field in fields)
                ezkoFieldComboBox.Items.Add(field);
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
                if(actionName.Length < 1)
                {
                    BasicMessagesHandler.ShowInformationMessage("Nezadali ste názov výkonu");
                    actionNameTextBox.Focus();
                    result = false;
                }
                else if(shortcut.Length < 1)
                {
                    BasicMessagesHandler.ShowInformationMessage("Nezadali ste skratku výkonu");
                    actionShortcutTextBox.Focus();
                    result = false;
                }
                else if (insuranceCompany == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Nevybrali ste kód poistovne");
                    companyCodeComboBox.Focus();
                    result = false;
                }
                else if(ezkoController.ActionExists(actionName, shortcut))
                {
                    BasicMessagesHandler.ShowInformationMessage("Výkon s daným názvom alebo skratkou už existuje");
                    actionNameTextBox.Focus();
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
                 if(ezkoController.CreateAction(actionName, shortcut, longName,
                        material, recommendedLength, costs, margin, insuranceCompanyMargin,
                        insuranceCompany, field, hasSpecification))
                        BasicMessagesHandler.ShowInformationMessage("Výkon bol úspešne vytvorený");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas vytvárania výkonu sa vyskytla chyba");
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
        private void EditActionForm_Load(object sender, EventArgs e)
        {
            actionNameTextBox.MaxLength = 30;
            actionShortcutTextBox.MaxLength = 12;

            recommendedLengthUpDown.Maximum = decimal.MaxValue;
            costsUpDown.Maximum = decimal.MaxValue;
            companyMarginUpDown.Maximum = decimal.MaxValue;
            recommendedLengthUpDown.Maximum = decimal.MaxValue;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        #endregion
    }
}
