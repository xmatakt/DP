using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.Forms
{
    public partial class LoginForm : Form
    {
        private EzkoController ezkoController;
        private WorkingInfoForm workingInfoForm;

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

        public LoginForm(EzkoController ezkoController)
        {
            InitializeComponent();
            this.ezkoController = ezkoController;

#if DEBUG
            userNameTextBox.Text = "doktor";
            passwordTextBox.Text = "123";
            passwordTextBox.Focus();
#else
            userNameTextBox.Focus();
#endif
        }

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
            //Close();
        }
        #endregion

        private void LoginForm_Load(object sender, EventArgs e)
        {
            userNameLabel.Text = LanguageController.GetColonText(StringKeys.Login);
            passwordLabel.Text = LanguageController.GetColonText(StringKeys.Password);
            loginButton.Text = LanguageController.GetText(StringKeys.LogIn);
        }

        private void StartLogin()
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            workingInfoForm = new WorkingInfoForm("Prihlasovanie", LanguageController.GetText(StringKeys.Working));
            workingInfoForm.ShowDialog();
        }

        private void LoginUser()
        {
            try
            {
                var login = userNameTextBox.Text.Trim();
                var password = passwordTextBox.Text.Trim();

                switch (ezkoController.ValidateLogin(login, password))
                {
                    case DatabaseCommunicator.Enums.LoginResultEnum.SuccesfullyLoggedIn:
                        GlobalSettings.User = ezkoController.GetUserByLogin(login);
                        DialogResult = DialogResult.OK;
                        break;
                    case DatabaseCommunicator.Enums.LoginResultEnum.BadLoginData:
                        BasicMessagesHandler.ShowErrorMessage(LanguageController.GetText(StringKeys.BadLoginData));
                        DialogResult = DialogResult.None;
                        break;
                    case DatabaseCommunicator.Enums.LoginResultEnum.InactiveUser:
                        BasicMessagesHandler.ShowErrorMessage(LanguageController.GetText(StringKeys.InactiveUser));
                        DialogResult = DialogResult.None;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage(LanguageController.GetText(StringKeys.LoginError), e);
            }
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            LoginUser();
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            workingInfoForm.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            StartLogin();
        }

        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                passwordTextBox.Focus();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                StartLogin();
            }
        }
    }
}