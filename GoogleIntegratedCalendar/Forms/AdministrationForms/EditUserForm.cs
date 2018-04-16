using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using ExceptionHandler;
using EZKO.Controllers;
using EZKO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DatabaseCommunicator.Model;

namespace EZKO.Forms.AdministrationForms
{
    /// <summary>
    /// Class which provides functionality to create or edit User entities
    /// </summary>
    public partial class EditUserForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private WorkingInfoForm workingInfoForm;
        private Dictionary<string, int> userRolesDictionary;
        private User user;

        #region UserData
        private string login
        {
            get { return userNameTextBox.Text.Trim(); }
            set { userNameTextBox.Text = value.Trim(); }
        }
        private string email
        {
            get { return emailTextBox.Text.Trim(); }
            set { emailTextBox.Text = value.Trim(); }
        }

        private string password
        {
            get
            {
                string result = passwordTextBox.Text.Trim();
                if (result == "")
                    result = null;

                return result;
            }
            set { passwordTextBox.Text = value.Trim(); }
        }

        private string confirmedPassword
        {
            get
            {
                string result = confirmPasswordTextBox.Text.Trim();
                if (result == "")
                    result = null;

                return result;
            }
            set { confirmPasswordTextBox.Text = value.Trim(); }
        }

        private int roleID
        {
            get
            {
                if (roleComboBox.SelectedItem != null)
                    return userRolesDictionary[(string)roleComboBox.SelectedItem];
                else
                    return -1;
            }
            set { roleID = value; }
        }

        private string avatarImagePath = null;
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

        public EditUserForm()
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = WorkingTypeEnum.Creating;
            InitializeForm();
        }

        public EditUserForm(User user)
        {
            InitializeComponent();
            ezkoController = GlobalSettings.EzkoController;
            this.user = user;
            workingType = WorkingTypeEnum.Editing;
            addButton.Text = "Upraviť používateľa";

            InitializeForm();
        }

        private void InitializeForm()
        {
            if(user != null)
            {
                login = user.Login;
                email = user.Email;
                avatarPictureBox.Image = DirectoriesController.GetImage(user.AvatarImagePath, Properties.Resources.noUserImage);
                userNameTextBox.ReadOnly = true;
            }

            userRolesDictionary = new Dictionary<string, int>();
            InitializeRoleComboBox();
        }

        private void InitializeRoleComboBox()
        {
            int selectedIndex = -1;
            var roles = ezkoController.GetUserRoles();

            if(roles != null)
                foreach (var role in roles)
                {
                    var localizedRoleName = GetLocalizedRoleName(role.ID);
                    int index = roleComboBox.Items.Add(localizedRoleName);
                    userRolesDictionary.Add(localizedRoleName, role.ID);

                    if (user != null && role.ID == user.RoleID)
                        selectedIndex = index;
                }

            if (selectedIndex >= 0)
                roleComboBox.SelectedIndex = selectedIndex;
        }

        private void CreateOrUpdate()
        {
            switch (workingType)
            {
                case WorkingTypeEnum.Creating:
                    Cursor = Cursors.WaitCursor;
                    CreateUser();
                    Cursor = Cursors.Default;
                    break;
                case WorkingTypeEnum.Editing:
                    Cursor = Cursors.WaitCursor;
                    EditUser();
                    Cursor = Cursors.Default;
                    break;
                default:
                    break;
            }
        }

        private void CreateUser()
        {
            if (ValidateData())
            {
                string rootDirectoryPath = DirectoriesController.GetUserRootFolder(login);
                string ezkoAvatarImagePath = DirectoriesController.GetEzkoUserImagePath(login, avatarImagePath);

                //if creation of new user is succesful, we need co create EZKO directory
                //structure for newly created user and copy image to that location
                if (ezkoController.CreateUser(login, email, roleID, password, rootDirectoryPath, ezkoAvatarImagePath) &&
                    DirectoriesController.CreateUserFolderStructure(login) &&
                    DirectoriesController.CopyFile(avatarImagePath, ezkoAvatarImagePath))
                {
                    BasicMessagesHandler.ShowInformationMessage("Požívateľ bol úspešne vytvorený");
                }
                else
                {
                    BasicMessagesHandler.ShowErrorMessage("Pri vytváraní požívateľa sa vyskytla chyba");
                }
            }
            else
                DialogResult = DialogResult.None;
        }

        private void EditUser()
        {
            if(ValidateData())
            {
                string rootDirectoryPath = user.RootDirectoryPath;
                string ezkoAvatarImagePath = DirectoriesController.GetEzkoUserImagePath(user.Login, avatarImagePath);

                //if editing of the user is succesful, we need to copy choosen image into users EZKO root folder
                if (ezkoController.EditUser(user, email, roleID, password, ezkoAvatarImagePath) &&
                    DirectoriesController.CopyFile(avatarImagePath, ezkoAvatarImagePath))
                {
                    //BasicMessagesHandler.ShowInformationMessage("Požívateľ bol úspešne upravený");
                }
                else
                {
                    BasicMessagesHandler.ShowErrorMessage("Pri editovaní požívateľa sa vyskytla chyba");
                }
            }
            else
                DialogResult = DialogResult.None;
        }

        private bool ValidateData()
        {
            bool result = false;

            if(login.Length < 1)
            {
                BasicMessagesHandler.ShowInformationMessage("Nezadali ste používateľské meno");
                userNameTextBox.Focus();
                result = false;
            }
            else if(email.Length < 1)
            {
                BasicMessagesHandler.ShowInformationMessage("Nezadali ste email");
                emailTextBox.Focus();
                result = false;
            }
            else if(!email.Contains("@") || !email.Contains("."))
            {
                BasicMessagesHandler.ShowInformationMessage("Nezadali ste validný email");
                emailTextBox.Focus();
                result = false;
            }
            else if(roleID < 1)
            {
                BasicMessagesHandler.ShowInformationMessage("Nezvolili ste používateľskú rolu");
                roleComboBox.Focus();
                result = false;
            }
            else if (password == null && workingType == WorkingTypeEnum.Creating)
            {
                BasicMessagesHandler.ShowInformationMessage("Nezadali ste heslo");
                passwordTextBox.Focus();
                result = false;
            }
            else if (workingType == WorkingTypeEnum.Creating && (confirmedPassword == null || !password.Equals(confirmedPassword)))
            {
                BasicMessagesHandler.ShowInformationMessage("Heslá sa nezhodujú");
                confirmPasswordTextBox.Focus();
                result = false;
            }
            else if(workingType == WorkingTypeEnum.Creating && ezkoController.LoginExists(login))
            {
                BasicMessagesHandler.ShowInformationMessage("Zadané používateľské meno už existuje");
                userNameTextBox.Focus();
                result = false;
            }
            else
                result = true;

            return result;
        }

        private string GetLocalizedRoleName(int ID)
        {
            string result = "";

            switch (ID)
            {
                case (int)UserRoleEnum.Administrator:
                    result = LanguageController.GetText(StringKeys.Administrator);
                    break;
                case (int)UserRoleEnum.Doctor:
                    result = LanguageController.GetText(StringKeys.Doctor);
                    break;
                case (int)UserRoleEnum.Manager:
                    result = LanguageController.GetText(StringKeys.Manager);
                    break;
                case (int)UserRoleEnum.Nurse:
                    result = LanguageController.GetText(StringKeys.Nurse);
                    break;
                default:
                    break;
            }

            return result;
        }

        #region UI events
        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                avatarImagePath = openFileDialog.FileName;
                avatarPictureBox.Image = Image.FromFile(avatarImagePath);
            }
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked)
            {
                passwordTextBox.PasswordChar = '\0';
                confirmPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                passwordTextBox.PasswordChar = '*';
                confirmPasswordTextBox.PasswordChar = '*';
            }
        }

        private void confirmPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CreateOrUpdate();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
        }

        private void EditUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
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

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            formTitleLabel.Text = LanguageController.GetText(StringKeys.EditUserForm_Title);
            userNameLabel.Text = LanguageController.GetRequiredText(StringKeys.EditUserForm_UserName);
            emailLabel.Text = LanguageController.GetRequiredText(StringKeys.Email);
            roleLabel.Text = LanguageController.GetRequiredText(StringKeys.EditUserForm_UserRole);
            passwordLabel.Text = LanguageController.GetRequiredText(StringKeys.Password);
            confirmPasswordLabel.Text = LanguageController.GetRequiredText(StringKeys.EditUserForm_ConfirmPassword);
            chooseImageButton.Text = LanguageController.GetText(StringKeys.EditUserForm_ChooseImage);
            if(workingType == WorkingTypeEnum.Creating)
                addButton.Text = LanguageController.GetText(StringKeys.EditUserForm_CreateUser);
            else
                addButton.Text = LanguageController.GetText(StringKeys.EditUserForm_EditUser);
            cancelButton.Text = LanguageController.GetText(StringKeys.Cancel);
            showPasswordCheckBox.Text = LanguageController.GetText(StringKeys.EditUserForm_ShowPassword);

            userNameTextBox.MaxLength = 25;
            emailTextBox.MaxLength = 80;
            passwordTextBox.MaxLength = 128;
            confirmPasswordTextBox.MaxLength = 128;
        }
    }
}
