using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunicator.Model;
using System.Windows.Forms.Calendar;
using ExceptionHandler;
using DatabaseCommunicator.Enums;

namespace DatabaseCommunicator.Controllers
{
    /// <summary>
    /// Class which provides control over the database tables
    /// - provides CRUD operations on the database entities
    /// </summary>
    public class EzkoController : IDisposable
    {
        private bool disposed = false;
        private EzkoEntities db;

        public void CreateFirstUser()
        {
            var user = new User()
            {
                Login = "admin",
                Email = "iam@admin.com",
                UserRole = db.UserRoles.First(x => x.ID == (int)UserRoleEnum.Administrator),
                Password = PasswordController.GetPwdHash("admin"),
                RootDirectoryPath = @"C:\EZKO\Users",
                IsDeleted = false,
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        /// <summary>
        /// Creates new instance of CalendarController class
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        public EzkoController(string connectionString)
        {
            db = new EzkoEntities(connectionString);
        }

        #region Functions for calendar
        /// <summary>
        /// Return list of CalendarEvents from the database
        /// </summary>
        /// <param name="startDate">Start of required time period</param>
        /// <param name="endDate">End of required time period</param>
        /// <returns></returns>
        public IQueryable<CalendarEvent> GetEvents(DateTime startDate, DateTime endDate)
        {
            return db.CalendarEvents.Where(x =>
                x.StartDate >= startDate &&
                x.EndDate <= endDate &&
                !x.IsDeleted);
        }

        /// <summary>
        /// Use this method to delete desired CalendarEvents by their ids
        /// </summary>
        /// <param name="eventIds">Ids of events to be deleted</param>
        /// <returns>Value indicating whether items was deleted successfully</returns>
        public bool DeleteEvents(List<int> eventIds)
        {
            bool result = true;
            try
            {
                bool saveChanges = false;
                foreach (var eventId in eventIds)
                {
                    CalendarEvent _event = db.CalendarEvents.FirstOrDefault(x => x.ID == eventId);
                    if (_event == null)
                        continue;

                    _event.IsDeleted = true;
                    saveChanges = true;
                }

                if (saveChanges)
                    db.SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Add new CalendarEvents into database
        /// </summary>
        /// <param name="newItems">Events to add</param>
        /// <returns>Value indicating whether items was added successfully</returns>
        public bool AddCalendarEvents(List<CalendarItem> newItems)
        {
            throw new NotImplementedException();
            bool result = true;
            if (newItems.Count == 0)
                return result;

            try
            {
                int lastEventId = db.CalendarEvents.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault() + 1;
                List<CalendarEvent> newEvents = new List<CalendarEvent>();
                foreach (var item in newItems)
                {
                    var eventColor = new CalendarEventColor()
                    {
                        R = item.BackgroundColor.IsEmpty ? 203 : item.BackgroundColor.R,
                        G = item.BackgroundColor.IsEmpty ? 219 : item.BackgroundColor.G,
                        B = item.BackgroundColor.IsEmpty ? 238 : item.BackgroundColor.B,
                    };

                    var newItem = new CalendarEvent()
                    {
                        GoogleEventID = item.GoogleEventID ?? (DateTime.UtcNow.Subtract(item.StartDate)).TotalSeconds.ToString(),
                        Summary = item.Text,
                        Description = item.Description,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IsSynchronized = true,
                        IsDeleted = item.IsDeleted,
                        CalendarEventColor = eventColor,
                    };
                    newEvents.Add(newItem);
                    item.GoogleEventID = newItem.GoogleEventID;
                }

                db.CalendarEvents.AddRange(newEvents);
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Update CalendarEvents in database
        /// </summary>
        /// <param name="items">Events to update</param>
        /// <returns>Value indicating whether items was updated successfully</returns>
        public bool UpdateCalendarEvents(List<CalendarItem> items)
        {
            bool result = true;
            if (items.Count == 0)
                return result;

            try
            {
                foreach (var item in items)
                {
                    var calendarEvent = db.CalendarEvents.First(x => x.ID == item.DatabaseEntityID.Value);

                    var eventColor = calendarEvent.CalendarEventColor;

                    eventColor.R = item.BackgroundColor.IsEmpty ? 203 : item.BackgroundColor.R;
                    eventColor.G = item.BackgroundColor.IsEmpty ? 219 : item.BackgroundColor.G;
                    eventColor.B = item.BackgroundColor.IsEmpty ? 238 : item.BackgroundColor.B;

                    calendarEvent.GoogleEventID = item.GoogleEventID;
                    calendarEvent.Summary = item.Text;
                    calendarEvent.Description = item.Description;
                    calendarEvent.StartDate = item.StartDate;
                    calendarEvent.EndDate = item.EndDate;
                    calendarEvent.IsSynchronized = true;
                    calendarEvent.IsDeleted = item.IsDeleted;
                    calendarEvent.CalendarEventColor = eventColor;
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion

        #region Patients
        /// <summary>
        /// Get patient names from database
        /// </summary>
        /// <returns>Full name string of every nondeleted patient in database</returns>
        public IEnumerable<string> GetPatientNames()
        {
            IEnumerable<string> result = null;
            try
            {
                result = db.Patients.Where(x => !x.IsDeleted)
                    .Select(x => x.Name + " " + x.Surname);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Get nondeleted patients from database
        /// </summary>
        /// <returns>Every nondeleted patient in database</returns>
        public IQueryable<Patient> GetPatients()
        {
            IQueryable<Patient> result = null;
            try
            {
                result = db.Patients.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        public Patient CreatePatient(string name, string surame, string email, string phone)
        {
            Patient result = null;
            try
            {
                Contact contact = CreateContact(email, phone);

                if (contact != null)
                {
                    result = new Patient()
                    {
                        Name = name,
                        Surname = surame,
                        Contact = contact,
                    };
                    db.Patients.Add(result);

                    if (!SaveChanges())
                        result = null;
                }
            }
            catch (Exception e)
            {
                result = null;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        private Contact CreateContact(string email, string phone)
        {
            Contact result = null;
            try
            {
                result = new Contact()
                {
                    Email = email,
                    Phone = phone,
                };
                db.Contacts.Add(result);
            }
            catch (Exception e)
            {
                result = null;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion

        #region Users
        /// <summary>
        /// Function validates, if entered login data are correct and user can be logged into system
        /// </summary>
        /// <param name="login">Entered login</param>
        /// <param name="password">Entered password</param>
        /// <returns></returns>
        public LoginResultEnum ValidateLogin(string login, string password)
        {
            LoginResultEnum result = LoginResultEnum.BadLoginData;

            var user = db.Users.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                if (user.IsDeleted)
                    result = LoginResultEnum.InactiveUser;
                else
                {
                    var pwdHash = PasswordController.GetPwdHash(password);
                    if (user.Password.Equals(pwdHash))
                        result = LoginResultEnum.SuccesfullyLoggedIn;
                }
            }

            return result;
        }

        /// <summary>
        /// Obtain User entity with certain login from database
        /// </summary>
        /// <param name="login">User login which will be used to search query</param>
        /// <returns>User if user with provided login exists, else returns null</returns>
        public User GetUserByLogin(string login)
        {
            return db.Users.FirstOrDefault(x => x.Login == login);
        }

        /// <summary>
        /// Get doctors from the database
        /// </summary>
        /// <returns>All nondeleted users with Role = Doctor</returns>
        public IQueryable<User> GetDoctors()
        {
            IQueryable<User> result = null;
            try
            {
                result = db.Users.Where(x => (x.RoleID == (int)UserRoleEnum.Doctor) && !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Return teh user roles of the system
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserRole> GetUserRoles()
        {
            IEnumerable<UserRole> result = null;
            try
            {
                result = db.UserRoles;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Creates the user from the provided parameters
        /// </summary>
        /// <returns>Value whether the creating of the user was succesful or not</returns>
        public bool CreateUser(string login, string email, int roleID,
            string password, string rootDirectoryPath, string avatarImagePath)
        {
            User newUser = new User()
            {
                Login = login,
                Email = email,
                RoleID = roleID,
                Password = PasswordController.GetPwdHash(password),
                RootDirectoryPath = rootDirectoryPath,
                AvatarImagePath = avatarImagePath,
                IsDeleted = false
            };
            db.Users.Add(newUser);

            return SaveChanges();
        }

        /// <summary>
        /// Check if login exists
        /// </summary>
        /// <param name="login"></param>
        /// <returns>VAlue indicating whether user with provided login exists and is not deleted</returns>
        public bool LoginExists(string login)
        {
            bool result = false;
            try
            {
                User user = db.Users.FirstOrDefault(x => x.Login == login);

                if (user != null && !user.IsDeleted)
                    result = true;
            }
            catch (Exception e)
            {
                result = true;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion

        #region Insurance companies
        /// <summary>
        /// Obtain insurance companies from the database
        /// </summary>
        /// <returns>All insurance companies from the database which are not deleted</returns>
        public IEnumerable<InsuranceCompany> GetInsuranceCompanies()
        {
            IEnumerable<InsuranceCompany> result = null;
            try
            {
                result = db.InsuranceCompanies.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Obtain value to indicate if insurance company with provided name exists
        /// </summary>
        /// <param name="name">Name of the insurance company</param>
        /// <returns>Value indicating if insurance company with provided name exists</returns>
        public bool InsuranceCompanyNameExists(string name)
        {
            bool result = false;

            try
            {
                InsuranceCompany company = db.InsuranceCompanies.FirstOrDefault(x => x.Name.Equals(name));
                if (company != null && !company.IsDeleted)
                    result = true;
            }
            catch (Exception e)
            {
                result = true;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Obtain value to indicate if insurance company with provided code exists
        /// </summary>
        /// <param name="code">Insurance company code</param>
        /// <returns>Value indicating if insurance company with provided code exists</returns>
        public bool InsuranceCompanyCodeExists(string code)
        {
            bool result = false;

            try
            {
                InsuranceCompany company = db.InsuranceCompanies.FirstOrDefault(x => x.Code.Equals(code));
                if (company != null && !company.IsDeleted)
                    result = true;
            }
            catch (Exception e)
            {
                result = true;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Create insurance company with provided name and code
        /// </summary>
        /// <param name="insuranceCompanyName">Name of the insurance company</param>
        /// <param name="insuranceCompanyCode">Code of the insurance company</param>
        /// <returns>Value indicating whether the creation of the insurance company was successfull</returns>
        public bool CreateInsuranceCompany(string insuranceCompanyName, string insuranceCompanyCode)
        {
            InsuranceCompany company = new InsuranceCompany()
            {
                Name = insuranceCompanyName,
                Code = insuranceCompanyCode,
                IsDeleted = false
            };
            db.InsuranceCompanies.Add(company);

            return SaveChanges();
        }
        #endregion

        #region EZKO fields
        /// <summary>
        /// Get EZKO fields
        /// </summary>
        /// <returns>All nondeleted fields from the database</returns>
        public IEnumerable<Field> GetFields()
        {
            IEnumerable<Field> result = null;
            try
            {
                result = db.Fields.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion

        #region  Actions
        /// <summary>
        /// Get actions
        /// </summary>
        /// <returns>All of the nondeleted actions from the database</returns>
        public IQueryable<Model.Action> GetActions()
        {
            IQueryable<Model.Action> result = null;
            try
            {
                result = db.Actions.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Find out if action with provided name and shotcut already exists in the database
        /// </summary>
        /// <param name="name">Name of the action</param>
        /// <param name="shortcut">Short name of the action</param>
        /// <returns>Value indicating whether action with provided name and short name exists in the database</returns>
        public bool ActionExists(string name, string shortcut)
        {
            bool result = true;

            try
            {
                Model.Action action = db.Actions.FirstOrDefault(x =>
                (x.Name.Equals(name) || x.ShortName.Equals(shortcut)) &&
                !x.IsDeleted);

                if (action == null)
                    result = false;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Create action
        /// </summary>
        /// <returns>VAlue indicating whether the creation of new action was successfull</returns>
        public bool CreateAction(string actionName, string shortcut, string longName, string material,
            int recommendedLength, decimal costs, decimal margin, decimal insuranceCompanyMargin, InsuranceCompany insuranceCompany, Field field, bool hasSpecification)
        {
            bool result = false;
            try
            {
                Model.Action action = new Model.Action()
                {
                    Name = actionName,
                    ShortName = shortcut,
                    LongName = longName,
                    Material = material,
                    RecommendedLength = recommendedLength,
                    Costs = costs,
                    Margin = margin,
                    InsuranceCompanyMargin = insuranceCompanyMargin,
                    InsuranceCompany = insuranceCompany,
                    Field = field,
                    HasSpecification = hasSpecification,
                    IsDeleted = false
                };
                db.Actions.Add(action);
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion

        #region CalnedarEvents
        public CalendarEvent CreateCalendarEvent(Patient eventPatient, List<User> doctors, DateTime eventStartDateTime, decimal eventDuration, string notificationEmails, string eventNote, List<Model.Action> plannedActions, string plannedText, EventState eventState)
        {
            CalendarEvent result = null;

            try
            {
                result = new CalendarEvent()
                {
                    ColorID = db.CalendarEventColors.First(x => x.EventStateID == eventState.ID).ID,
                    GoogleEventID = UnixTimestamp(DateTime.Now),
                    StartDate = eventStartDateTime,
                    EndDate = GetEventEndDate(eventStartDateTime, eventDuration),
                    Summary = CreateEventSummary(eventPatient, plannedActions),
                    Description = eventNote,
                    Patient = eventPatient,
                    NotificationEmails = notificationEmails,
                    Actions = plannedActions,
                    Users = doctors,
                    PlanedActionText = plannedText,
                    EventState = eventState,

                    IsSynchronized = false,
                    IsDeleted = false,
                };
                db.CalendarEvents.Add(result);

                if (!SaveChanges())
                    result = null;
            }
            catch (Exception e)
            {
                result = null;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        public IQueryable<CalendarEvent> GetEvents()
        {
            return db.CalendarEvents.Where(x => !x.IsDeleted);
        }
        public CalendarEvent GetEvent(int calendarEventID)
        {
            CalendarEvent result = null;

            try
            {
                result = db.CalendarEvents.FirstOrDefault(x => x.ID == calendarEventID);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        public bool UpdateCalendarEvent(CalendarEvent calendarEvent, List<User> doctors, DateTime startDate, decimal eventDuration,
           string notificationEmails, string eventNote, List<Model.Action> plannedActions, string plannedText, EventState eventState,
           List<DoneActionNotePair> doneActions, string doneText)
        {
            bool result = false;

            try
            {
                calendarEvent.ColorID = db.CalendarEventColors.First(x => x.EventStateID == eventState.ID).ID;
                calendarEvent.Users = doctors;
                calendarEvent.StartDate = startDate;
                calendarEvent.EndDate = GetEventEndDate(startDate, eventDuration);
                calendarEvent.NotificationEmails = notificationEmails;
                calendarEvent.Summary = CreateEventSummary(calendarEvent.Patient, plannedActions);
                calendarEvent.Description = eventNote;
                calendarEvent.Actions = plannedActions;
                calendarEvent.PlanedActionText = plannedText;
                calendarEvent.EventState = eventState;
                calendarEvent.CalendarEventExecutedActions = GetEventExecutedActions(calendarEvent, doneActions);
                calendarEvent.ExecutedActionText = doneText;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        public bool DeleteEvent(CalendarEvent calendarEvent)
        {
            bool result = false;

            try
            {
                calendarEvent.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        #endregion

        #region Others

        /// <summary>
        /// Get EventState entities from the database
        /// </summary>
        /// <returns>All EventState entities existing in the database</returns>
        public IQueryable<EventState> GetEventStates()
        {
            IQueryable<EventState> result = null;
            try
            {
                result = db.EventStates;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Saves all made changes
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            bool result = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }
            return result;
        }
        #endregion

        #region Private methods
        private string UnixTimestamp(DateTime dateTime)
        {
            return ((Int32)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
        }

        private DateTime GetEventEndDate(DateTime eventStartDateTime, decimal eventDuration)
        {
            return eventStartDateTime.AddMinutes((double)eventDuration);
        }

        private string CreateEventSummary(Patient patient, List<Model.Action> actions)
        {
            string result = patient.FullName;

            if (actions.Count > 0)
                result += " / ";

            bool isFirst = true;
            foreach (var item in actions)
            {
                if (isFirst)
                {
                    result += item.ShortName;
                    isFirst = false;
                }
                else
                    result += ", " + item.ShortName;
            }

            return result;
        }

        private ICollection<CalendarEventExecutedAction> GetEventExecutedActions(CalendarEvent calendarEvent, List<DoneActionNotePair> doneActions)
        {
            List<CalendarEventExecutedAction> result = new List<CalendarEventExecutedAction>();

            try
            {
                foreach (var item in doneActions)
                {
                    ExecutedActionNote note = new ExecutedActionNote() { Note = item.ActionNote };

                    result.Add(new CalendarEventExecutedAction()
                    {
                        Action = item.DoneAction,
                        ExecutedActionNote = note,
                        CalendarEvent = calendarEvent,
                    });
                }
            }
            catch (Exception e)
            {
                result = null;
                BasicMessagesHandler.LogException(e);
            }

            if (result != null && result.Count <= 0)
                result = null;

            return result;
        }
        #endregion

        #region disposing
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
            }
            // Free any unmanaged objects here.

            disposed = true;
        }

        public EventState GetEventState(EventStateEnum state)
        {
            EventState result = null;

            try
            {
                result = db.EventStates.FirstOrDefault(x => x.ID == (int)state);
            }
            catch (Exception e)
            {
                result = null;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion
    }
}
