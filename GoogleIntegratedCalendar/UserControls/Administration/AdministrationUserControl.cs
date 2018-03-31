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
        private EzkoSectionsControlPanel sectionsControlPanel;
        private BudgetsControlPanel budgetsControlPanel;
        private FormularsControlPanel formularsControlPanel;
        private FieldsControlPanel fieldsControlPanel;

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

        private void ShowSectionsPanel()
        {
            if (sectionsControlPanel == null)
                sectionsControlPanel = new EzkoSectionsControlPanel();
            else
                sectionsControlPanel.UpdateControl();

            AddControlToMainPanel(sectionsControlPanel);
        }

        private void ShowBudgetsPanel()
        {
            if (budgetsControlPanel == null)
                budgetsControlPanel = new BudgetsControlPanel();

            budgetsControlPanel.UpdatePatientTextBox();

            AddControlToMainPanel(budgetsControlPanel);
        }

        private void ShowFormularsPanel()
        {
            if (formularsControlPanel == null)
                formularsControlPanel = new FormularsControlPanel();

            AddControlToMainPanel(formularsControlPanel);
        }

        private void ShowFieldsPanel()
        {
            if (fieldsControlPanel == null)
                fieldsControlPanel = new FieldsControlPanel();

            AddControlToMainPanel(fieldsControlPanel);
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
            var form = new EditUserForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowUsersPanel();
                userControlPanel.UpdateControl();
            }
        }

        private void insuranceCompaniesMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditInsuranceCompanyForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowInsurancePanel();
                insuranceCompaniesControlPanel.UpdateControl();
            }
        }

        private void actionsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditActionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowActionsPanel();
                actionsControlPanel.UpdateControl();
            }
        }

        private void infrastructureMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditInfrastructureForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowInfrastructurePanel();
                infrastructureControlPanel.UpdateControl();
            }
        }

        private void ezkoSectionsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditSectionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowSectionsPanel();
                sectionsControlPanel.UpdateControl();
            }
        }

        private void budgetsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditBudgetForm(Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowBudgetsPanel();
                budgetsControlPanel.UpdateControl();
            }
        }

        private void formularsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditFormularForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowFormularsPanel();
                formularsControlPanel.UpdateControl();
            }
        }

        private void ezkoFieldsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditFieldForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowFieldsPanel();
                fieldsControlPanel.UpdateControl();
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

        private void ezkoSectionsMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowSectionsPanel();
        }

        private void budgetsMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowBudgetsPanel();
        }

        private void formularsMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowFormularsPanel();
        }

        private void ezkoFieldsMenuItem_ListButtonClick(object sender, EventArgs e)
        {
            ShowFieldsPanel();
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
