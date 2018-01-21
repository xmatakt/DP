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
    public partial class EditFormularForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private DatabaseCommunicator.Model.Form formular;

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
        #endregion

        public EditFormularForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = workingType;
        }

        public EditFormularForm(DatabaseCommunicator.Model.Form formular)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.formular = formular;
            addButton.Text = "Upraviť formulár";

            InitializeForm();
        }

        #region Private methods
        private void InitializeForm()
        {
            if(formular != null)
            {
                name = formular.Name;
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
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať názov formulára");
                    nameTextBox.Focus();
                    result = false;
                }
                else if(name.Length < 3)
                {
                    BasicMessagesHandler.ShowInformationMessage("Názov formulára mussí mať aspoň 3 znaky");
                    nameTextBox.Focus();
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
                    if (ezkoController.CreateFormular(name))
                        BasicMessagesHandler.ShowInformationMessage("Anamnestický formulár bol úspešne vytvorený");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas vytvárania anamnestického formulára sa vyskytla chyba");
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
                    if (!ezkoController.EditFormular(formular, name))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy anamnestického formulára sa vyskytla chyba");
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
        private void EditFormularForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        #endregion
    }
}
