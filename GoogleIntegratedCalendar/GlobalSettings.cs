using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKO
{
    /// <summary>
    /// Static class for holding application settings from .config file etc.
    /// </summary>
    public static class GlobalSettings
    {
        //public static string ConnectionString = @"data source=ASUSPC;initial catalog=Ezko2;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";
        public static string ConnectionString = @"data source=DELLWIN8;initial catalog=Ezko2;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";
        //public static string User = "";
        public static DatabaseCommunicator.Model.User User = null;
        public static DatabaseCommunicator.Controllers.EzkoController EzkoController = null;
        //public static string LanguagePrefix = "sk-SK";
        //public static string LanguagePrefix = "en-US";
        public static string LanguagePrefix = "";
        public static string EzkoRootFolderPath = @"C:\EZKO";
        public static string UserRootFolderPath = @"C:\EZKO\Users";
        public static string PatientsRootFolderPath = @"C:\EZKO\Patients";
        public static string LogFilePath = @"C:\EZKO\.errorLog.log";

        public static string GoogleCalendarUserName = "timo";

        /// <summary>
        /// Loads setting from the App.config file
        /// </summary>
        public static void Load()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            LanguagePrefix = ConfigurationManager.AppSettings["Language"];
            EzkoRootFolderPath = ConfigurationManager.AppSettings["EzkoRootFolderPath"];
            UserRootFolderPath = ConfigurationManager.AppSettings["UserRootFolderPath"];
            PatientsRootFolderPath = ConfigurationManager.AppSettings["PatientsRootFolderPath"];
            GoogleCalendarUserName = ConfigurationManager.AppSettings["GoogleCalendarUserName"];
            LogFilePath = ConfigurationManager.AppSettings["LogFilePath"];

            EzkoController = new DatabaseCommunicator.Controllers.EzkoController(ConnectionString);
        }
    }
}
