using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKO
{
    /// <summary>
    /// Class that holds keys used in language resource fiels
    /// </summary>
    public static class StringKeys
    {
        #region VisitControlPanel
        public static string NewVisit = "NewVisit";
        public static string Patient = "Patient";
        public static string  NewPatient= "NewPatient";
        public static string Name = "Name";
        public static string Surname = "Surname";
        public static string Phone = "Phone";
        public static string Email = "Email";
        public static string Doctor = "Doctor";
        public static string Start = "Start";
        public static string Duration = "Duration";
        public static string FastSettings = "FastSettings";
        public static string DivisibleBy5Error = "DivisibleBy5Error";
        public static string NotificationEmails = "NotificationEmails";
        public static string VisitNote = "VisitNote";
        public static string PlannedActions = "PlannedActions";
        public static string PlannedText = "PlannedText";
        public static string DoneActions = "DoneActions";
        public static string Action = "Action";
        public static string ActionOutput = "ActionOutput";
        public static string DoneActionsText = "DoneActionsText";
        public static string EventState = "EventState";
        public static string Reset = "Reset";
        public static string CreateEvent = "CreateEvent";
        public static string DeleteEvent = "DeleteEvent";
        public static string ReorderEvent = "ReorderEvent";
        public static string SaveEvent = "SaveEvent";
        public static string Minutes = "Minutes";
        #endregion

        #region AdministrationUserControl
        public static string Users = "Users";
        public static string UsersTooltip = "UsersTooltip";
        #endregion

        #region FindEventUserControl
        public static string PersonalSchedule = "PersonalSchedule";
        #endregion

        #region MainForm
        public static string Dashboard = "Dashboard";
        public static string Ambulantion = "Ambulantion";
        public static string Patients = "Patients";
        public static string Administration = "Administration";
        //public static string  = "";
        #endregion

        #region WorkingInfoForm
        public static string LoadingDashboardPanel = "LoadingDashboardPanel";
        public static string LoadingDataTitle = "LoadingDataTitle";
        public static string Working = "Working";
        #endregion

        #region LoginForm
        public static string Login = "Login";
        public static string Password = "Password";
        public static string LogIn = "Enter";
        public static string PreparingSystem = "PreparingSystem"; 
        #endregion

        #region ErrorMessages
        public static string LoginError = "LoginError";
        public static string InactiveUser = "InactiveUser";
        public static string BadLoginData = "BadLoginData";
        #endregion

        #region EditUserForm
        public static string EditUserForm_Title = "EditUserForm_Title";
        public static string EditUserForm_UserName = "EditUserForm_UserName";
        public static string EditUserForm_UserRole = "EditUserForm_UserRole";
        public static string EditUserForm_ConfirmPassword = "EditUserForm_ConfirmPassword";
        public static string EditUserForm_ChooseImage = "EditUserForm_ChooseImage";
        public static string EditUserForm_CreateUser = "EditUserForm_CreateUser";
        public static string EditUserForm_EditUser = "EditUserForm_EditUser";
        public static string EditUserForm_ShowPassword = "EditUserForm_ShowPassword";
        public static string Cancel = "Cancel";
        #endregion

        #region UserRoles
        public static string Administrator = "Administrator";
        public static string Manager = "Manager";
        public static string Nurse = "Nurse";
        //Doctor key exists
        #endregion
    }
}
