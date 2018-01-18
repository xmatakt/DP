using System;
using System.Windows.Forms;
using EZKO.Controllers;
using EZKO.Forms.AdministrationForms;
using DatabaseCommunicator.Controllers;
using System.Drawing;

namespace EZKO.UserControls.Administration
{
    public partial class AdministrationUserControl : UserControl
    {
        private EzkoController ezkoController;
        private UsersControlPanel userControlPanel;
        private InsuranceCompaniesControlPanel insuranceCompaniesControlPanel;
        private ActionsControlPanel actionsControlPanel;
        private InfrastructureControlPanel infrastructureControlPanel;

        public AdministrationUserControl()
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;

            userControlPanel = new UsersControlPanel();
            mainPanel.Controls.Add(userControlPanel);
            userControlPanel.Dock = DockStyle.Fill;
        }

        #region Public methods
        #endregion

        #region Private methods
        private void ShowUsersPanel()
        {
            if (userControlPanel == null)
                userControlPanel = new UsersControlPanel();

            AddControlToMainPanel(userControlPanel);
        }

        private void ShowInsurancePanel()
        {
            if (insuranceCompaniesControlPanel == null)
                insuranceCompaniesControlPanel = new InsuranceCompaniesControlPanel();

            AddControlToMainPanel(insuranceCompaniesControlPanel);
        }

        private void ShowActionsPanel()
        {
            if (actionsControlPanel == null)
                actionsControlPanel = new ActionsControlPanel();

            AddControlToMainPanel(actionsControlPanel);
        }

        private void ShowInfrastructurePanel()
        {
            if (infrastructureControlPanel == null)
                infrastructureControlPanel = new InfrastructureControlPanel();

            AddControlToMainPanel(infrastructureControlPanel);
        }

        private void AddControlToMainPanel(Control control)
        {
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }
        #endregion

        #region UI events
        private void AdministrationUserControl_Load(object sender, EventArgs e)
        {
            controlNameLabel.Text = LanguageController.GetText(StringKeys.Administration);
            usersMenuItem.MenuItemText = LanguageController.GetText(StringKeys.Users);
            usersMenuItem.TooltipText = LanguageController.GetText(StringKeys.UsersTooltip);

            userLoginLabel.Text = GlobalSettings.User?.Login;
            userPictureBox.Image = DirectoriesController.GetImage(GlobalSettings.User?.AvatarImagePath, Properties.Resources.noUserImage_white);
        }

        private void usersMnuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditUserForm(Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowUsersPanel();
                userControlPanel.UpdateControl();
            }
        }

        private void insuranceCompaniesMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditInsuranceCompanyForm(Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowInsurancePanel();
                insuranceCompaniesControlPanel.UpdateControl();
            }
        }

        private void actionsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditActionForm(Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowActionsPanel();
                actionsControlPanel.UpdateControl();
            }
        }

        private void infrastructureMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditInfrastructureForm(Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowInfrastructurePanel();
                infrastructureControlPanel.UpdateControl();
            }
        }

        private void usersMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowUsersPanel();
        }

        private void insuranceCompaniesMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowInsurancePanel();
        }

        private void actionsMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowActionsPanel();
        }

        private void infrastructureMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowInfrastructurePanel();
        }

        private void editLoggedUserButton_Click(object sender, EventArgs e)
        {
            if(GlobalSettings.User != null)
            {
                EditUserForm form = new EditUserForm(GlobalSettings.User);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (userControlPanel != null)
                        userControlPanel.UpdateControl();

                    userPictureBox.Image = DirectoriesController.GetImage(GlobalSettings.User?.AvatarImagePath, Properties.Resources.noUserImage_white);
                }
            }
        }
        #endregion
    }
}
