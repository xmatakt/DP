using System;
using System.Windows.Forms;
using EZKO.Controllers;
using EZKO.Forms.AdministrationForms;
using DatabaseCommunicator.Controllers;

namespace EZKO.UserControls.Administration
{
    public partial class AdministrationUserControl : UserControl
    {
        private EzkoController ezkoController;
        public AdministrationUserControl(EzkoController ezkoController)
        {
            InitializeComponent();

            this.ezkoController = ezkoController;
        }

        private void AdministrationUserControl_Load(object sender, EventArgs e)
        {
            controlNameLabel.Text = LanguageController.GetText(StringKeys.Administration);
            usersMenuItem.MenuItemText = LanguageController.GetText(StringKeys.Users);
            usersMenuItem.TooltipText = LanguageController.GetText(StringKeys.UsersTooltip);
        }

        private void usersMnuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditUserForm(ezkoController, Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //TODO: treba nieco?
            }
        }

        private void insuranceCompaniesMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditInsuranceCompanyForm(ezkoController, Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //TODO: treba nieco?
            }
        }

        private void actionsMenuItem_AddButtonClick(object sender, EventArgs e)
        {
            var form = new EditActionForm(ezkoController, Enums.WorkingTypeEnum.Creating);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //TODO: treba nieco?
            }
        }
    }
}
