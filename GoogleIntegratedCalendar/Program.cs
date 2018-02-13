using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MainForm());
                Application.Run(new TmpForm());
                //Application.Run(new Forms.AdministrationForms.EditUserForm(Enums.WorkingTypeEnum.Creating));
                //Application.Run(new Forms.AdministrationForms.EditInsuranceCompanyForm(Enums.WorkingTypeEnum.Creating));
                //Application.Run(new Forms.AdministrationForms.EditActionForm(Enums.WorkingTypeEnum.Creating));
                //Application.Run(new Forms.AdministrationForms.EditFieldForm(Enums.WorkingTypeEnum.Creating));
            }
            catch (Exception ex)
            {
                ExceptionHandler.BasicMessagesHandler.ShowErrorMessage("V programe sa vyskytla neočakávaná chyba. Kontaktujte " +
                    "dodávateľa softvéru prosím.", ex);
            }
        }
    }
}
