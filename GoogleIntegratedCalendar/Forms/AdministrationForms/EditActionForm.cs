using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Classes;
using EZKO.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EZKO.Forms.AdministrationForms
{
    /// <summary>
    /// Class which provides functionality to create or edit Ation entities
    /// </summary>
    public partial class EditActionForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private WorkingInfoForm workingInfoForm;
        private DatabaseCommunicator.Model.Action action;

        #region Private properties
        private string actionName
        {
            get
            {
                string result = actionNameTextBox.Text.Trim();
                if (result == "")
                    result = null;

                return result;
            }
            set { actionNameTextBox.Text = value; }
        }

        private string shortName
        {
            get
            {
                string result = actionShortcutTextBox.Text.Trim();
                if (result == "")
                    result = null;

                return result;
            }
            set { actionShortcutTextBox.Text = value; }
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
            set { longNameTextBox.Text = value; }
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
            set { materialRichTextBox.Text = value; }
        }

        private int recommendedLength
        {
            get { return (int)recommendedLengthUpDown.Value; }
            set { recommendedLengthUpDown.Value = value; }
        }

        private decimal costs
        {
            get { return costsUpDown.Value; }
            set { costsUpDown.Value = value; }
        }

        private decimal margin
        {
            get { return marginUpDown.Value; }
            set { marginUpDown.Value = value; }
        }

        private decimal? insuranceCompanyMargin
        {
            get { return companyMarginUpDown.Value; }
            set { companyMarginUpDown.Value = value.Value; }
        }

        private InsuranceCompany insuranceCompany
        {
            get
            {
                if (companyCodeComboBox.SelectedIndex < 0)
                    return null;

                return (InsuranceCompany)companyCodeComboBox.SelectedItem;
            }
            set { companyCodeComboBox.SelectedItem = value; }
        }

        private Field field
        {
            get
            {
                if (ezkoFieldComboBox.SelectedIndex < 0 || ezkoFieldComboBox.SelectedIndex == 0)
                    return null;

                return (Field)ezkoFieldComboBox.SelectedItem;
            }
            set
            {
                ezkoFieldComboBox.SelectedItem = value;
            }
        }

        private bool hasSpecification
        {
            get { return hasSpecificationCheckBox.Checked; }
            set { hasSpecificationCheckBox.Checked = value; }
        }
        #endregion

        //Just for testing purpose
        //public EditActionForm(WorkingTypeEnum workingType)
        //{
        //    InitializeComponent();

        //    ezkoController = new EzkoController(GlobalSettings.ConnectionString);
        //    this.workingType = workingType;

        //    InitializeForm();
        //}

        public EditActionForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = workingType;

            InitializeForm();
        }

        public EditActionForm(DatabaseCommunicator.Model.Action action)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.action = action;
            addButton.Text = "Upraviť výkon";

            InitializeForm();
        }

        #region Private methods

        private void LoadAction()
        {
            if (action == null)
                return;
            try
            {
                actionName = action.Name;
                shortName = action.ShortName;
                longName = action.LongName;
                material = action.Material;
                recommendedLength = action.RecommendedLength;
                costs = action.Costs;
                margin = action.Margin;
                if(action.Field != null)
                    field = action.Field;
                insuranceCompany = action.InsuranceCompany;
                insuranceCompanyMargin = action.InsuranceCompanyMargin;
                hasSpecification = action.HasSpecification;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri načítavaní výkonu sa vyskytla chyba", e);
            }
        }
        private void InitializeForm(InsuranceCompany company = null)
        {
            InitializeInsuranceCompaniesComboBox();
            InitializeEZKOFieldsComboBox();
        }

        private void InitializeInsuranceCompaniesComboBox()
        {
            //int selectedIndex = -1;
            var companies = ezkoController.GetInsuranceCompanies();
            if (companies == null)
                return;

            foreach (var company in companies)
            {
                /*int index =*/ companyCodeComboBox.Items.Add(company);
                //if (action != null && action.InsuranceCompanyID == company.ID)
                //    selectedIndex = index;
            }

            //if (selectedIndex >= 0)
            //    companyCodeComboBox.SelectedIndex = selectedIndex;
        }

        private void InitializeEZKOFieldsComboBox()
        {
            //int selectedIndex = -1;
            ezkoFieldComboBox.Items.Add("Bez prepojenia na EZKO pole");
            var fields = ezkoController.GetFields();
            if (fields == null)
                return;

            foreach (var field in fields)
            {
                /*int index =*/ ezkoFieldComboBox.Items.Add(field);
                //if (action != null && action.EzkoFieldID == field.ID)
                //    selectedIndex = index;
            }

            //if (selectedIndex >= 0)
            //    ezkoFieldComboBox.SelectedIndex = selectedIndex;
            if(action != null && action.EzkoFieldID == null)
                ezkoFieldComboBox.SelectedIndex = 0;
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
                else if(shortName.Length < 1)
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
                else if(action == null && ezkoController.ActionExists(actionName, shortName))
                {
                    BasicMessagesHandler.ShowInformationMessage("Výkon s daným názvom alebo skratkou už existuje");
                    actionNameTextBox.Focus();
                    result = false;
                }
                else if (action != null  && ezkoController.ActionExists(action, actionName, shortName))
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
                 if(ezkoController.CreateAction(actionName, shortName, longName,
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
                    if (!ezkoController.EditAction(action, actionName, shortName, longName,
                            material, recommendedLength, costs, margin, insuranceCompanyMargin,
                            insuranceCompany, field, hasSpecification))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy výkonu sa vyskytla chyba");
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

            recommendedLengthUpDown.DecimalPlaces = 0;
            costsUpDown.DecimalPlaces = 2;
            marginUpDown.DecimalPlaces = 2;
            companyMarginUpDown.DecimalPlaces = 2;

            costsUpDown.Maximum = decimal.MaxValue;
            companyMarginUpDown.Maximum = decimal.MaxValue;
            recommendedLengthUpDown.Maximum = decimal.MaxValue;
            marginUpDown.Maximum = decimal.MaxValue;

            LoadAction();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        #endregion
    }
}
