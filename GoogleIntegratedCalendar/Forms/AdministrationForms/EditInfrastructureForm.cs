using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EZKO.Forms.AdministrationForms
{
    public partial class EditInfrastructureForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private Infrastructure infrastructure;

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
            set{ nameTextBox.Text = value; }
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

        private decimal? costs
        {
            get
            {
                decimal? val = null;

                if (costsNumericUpDown.Value > -1)
                    val = costsNumericUpDown.Value;

                return val;
            }
            set { costsNumericUpDown.Value = value.Value; }
        }

        private decimal? margin
        {
            get
            {
                decimal? val = null;

                if (marginNumericUpDown.Value > -1)
                    val = marginNumericUpDown.Value;

                return val;
            }
            set { marginNumericUpDown.Value = value.Value; }
        }
        #endregion

        public EditInfrastructureForm()
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = WorkingTypeEnum.Creating;
        }

        public EditInfrastructureForm(Infrastructure infrastructure)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.infrastructure = infrastructure;
            addButton.Text = "Upraviť infraštruktúru";

            InitializeForm();
        }

        #region Private methods
        private void InitializeForm()
        {
            if(infrastructure != null)
            {
                name = infrastructure.Name;
                description = infrastructure.Description;
                costs = infrastructure.Costs;
                margin = infrastructure.Margin;
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
                if(name == null || name.Length < 3)
                {
                    BasicMessagesHandler.ShowInformationMessage("Názov infraštruktúry musí mať aspoň 3 znaky!");
                    nameTextBox.Focus();
                    result = false;
                }
                else if(costs == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať výšku nákladov");
                    costsNumericUpDown.Focus();
                    result = false;
                }
                else if (margin == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať výšku marže");
                    marginNumericUpDown.Focus();
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
                    if(ezkoController.CreateInfrastructure(name, description, costs.Value, margin.Value))
                        BasicMessagesHandler.ShowInformationMessage("Infraštruktúra bola úspešne vytvorená");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas vytvárania infraštruktúry sa vyskytla chyba");
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
                    if(!ezkoController.EditInfrastructure(infrastructure, name, description, costs.Value, margin.Value))
                        BasicMessagesHandler.ShowInformationMessage("Počas úpravy infraštruktúry sa vyskytla chyba");
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
        private void EditInfrastructureForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
            costsNumericUpDown.Maximum = decimal.MaxValue;
            marginNumericUpDown.Maximum = decimal.MaxValue;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        #endregion
    }
}
