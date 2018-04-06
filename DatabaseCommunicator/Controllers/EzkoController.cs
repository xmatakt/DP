using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunicator.Model;
using System.Windows.Forms.Calendar;
using ExceptionHandler;
using DatabaseCommunicator.Enums;
using DatabaseCommunicator.Classes;
using System.Data.Entity;

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

        /// <summary>
        /// Function which was used in very first version of programm for the testing purpose. Can be removed now.
        /// </summary>
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

        #region Patients
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

        /// <summary>
        /// Get the patients, whose data contains proided text
        /// </summary>
        /// <param name="text">Text to look for</param>
        /// <returns>List of patients</returns>
        public IQueryable<Patient> GetPatients(string text)
        {
            IQueryable<Patient> result = null;
            try
            {
                result = db.Patients.Where(x => !x.IsDeleted);

                if(text != "")
                {
                    int id = -1;
                    if(int.TryParse(text, out id))
                    {
                        result = result.Where(x => x.ID == id);
                    }
                    else
                    {
                        text = text.ToUpper();

                        result = result.Where(x => x.Name.ToUpper().Contains(text) ||
                        x.Surname.ToUpper().Contains(text) ||
                        x.Contact.Phone.ToUpper().Contains(text) ||
                        x.Contact.Email.ToUpper().Contains(text) ||
                        (x.Address != null && x.Address.Street != null && x.Address.Street.ToUpper().Contains(text)) ||
                        (x.Address != null && x.Address.StreetNumber != null && x.Address.StreetNumber.ToUpper().Contains(text)) ||
                        (x.Address != null && x.Address.City != null && x.Address.City.ToUpper().Contains(text)) ||
                        (x.Address != null && x.Address.Country != null && x.Address.Country.ToUpper().Contains(text)));
                    }
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Creates patient nased on provided informations
        /// </summary>
        /// <returns>Created patient</returns>
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

        /// <summary>
        /// Creates patient based on provided informations
        /// </summary>
        /// <returns>Created patient</returns>
        public Patient CreatePatient(string name, string surname, DateTime? birthDate, string BIFO, string legalRepresentative,
            string titleBefore, string titleAfter, string birthNumber, InsuranceCompany insuranceCompany, SexEnum sex, Address address, Contact contact)
        {
            Patient result = null;
            try
            {
                if (contact != null)
                {
                    result = new Patient()
                    {
                        Name = name,
                        Surname = surname,
                        BirthDate = birthDate,
                        BIFO = BIFO,
                        LegalRepresentative = legalRepresentative,
                        TitleAfter = titleAfter,
                        TitleBefore = titleBefore,
                        BirthNumber = birthNumber,
                        InsuranceCompany = insuranceCompany,
                        SexID = (int)sex,
                        Address = address,
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

        /// <summary>
        /// Edits provided patient
        /// </summary>
        /// <returns>Value indicating wheter the editing of the patient was successfull</returns>
        public bool EditPatient(Patient patient, string name, string surname, DateTime? birthDate, string BIFO, string legalRepresentative, 
            string titleBefore, string titleAfter, string birthNumber, InsuranceCompany insuranceCompany, SexEnum sex,
            string street, string streetNumber, string city, string zip, string country, string phone, string alternativePhone,
            string email, string alternativeEmail, string facebook, string employment, string note, string avatarImagePath)
        {
            bool result = false;
            try
            {
                patient.Name = name;
                patient.Surname = surname;
                patient.BirthDate = birthDate;
                patient.BIFO = BIFO;
                patient.LegalRepresentative = legalRepresentative;
                patient.TitleBefore = titleBefore;
                patient.TitleAfter = titleAfter;
                patient.BirthNumber = birthNumber;
                patient.InsuranceCompany = insuranceCompany;
                patient.SexID = (int)sex;
                patient.Contact.Phone = phone;
                patient.Contact.AlternativePhone = alternativePhone;
                patient.Contact.Email = email;
                patient.Contact.AlternativeEmail = alternativeEmail;
                patient.Contact.Facebook = facebook;
                patient.Employment = employment;
                patient.Note = note;
                patient.IsDeleted = false;

                if (street != null || streetNumber != null || city != null || zip != null || country != null)
                {
                    if(patient.Address != null)
                    {
                        patient.Address.Street = street;
                        patient.Address.StreetNumber = streetNumber;
                        patient.Address.City = city;
                        patient.Address.PostNumber = zip;
                        patient.Address.Country = country;
                    }
                    else
                    {
                        Address address = new Address()
                        {
                            Street = street,
                            StreetNumber = streetNumber,
                            City = city,
                            PostNumber = zip,
                            Country = country
                        };
                        patient.Address = address;
                    }
                }

                //user has not to choose avatar image
                if (avatarImagePath != null)
                    patient.AvatarImagePath = avatarImagePath;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Removes provided patient from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <param name="item">Patient to remove</param>
        /// <returns>Value indicating whether the deletion of the patient was successfull</returns>
        public bool RemovePatient(Patient item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
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

        public IQueryable<User> GetUsers()
        {
            IQueryable<User> result = null;
            try
            {
                result = db.Users.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
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
        /// Get nurses from the database
        /// </summary>
        /// <returns>All nondeleted users with Role = Nurse</returns>
        public IQueryable<User> GetNurses()
        {
            IQueryable<User> result = null;
            try
            {
                result = db.Users.Where(x => (x.RoleID == (int)UserRoleEnum.Nurse) && !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Gets the available user roles
        /// </summary>
        /// <returns>Returns the user roles of the system</returns>
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
        /// Edits provided user
        /// </summary>
        /// <returns>VAlue indicating whether the editing of the user was successfull</returns>
        public bool EditUser(User user, string email, int roleID, string password, string avatarImagePath)
        {
            bool result = false;
            try
            {
                user.Email = email;
                user.RoleID = roleID;
                //user has not to edit existing password
                if (password != null)
                    user.Password = PasswordController.GetPwdHash(password);
                //user has not to choose avatar image
                if (avatarImagePath != null)
                    user.AvatarImagePath = avatarImagePath;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Removes provided user from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <param name="item">Patient to remove</param>
        /// <returns>Value indicating whether the deletion of the user was successfull</returns>
        public bool RemoveUser(User user)
        {
            bool result = false;

            try
            {
                user.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
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

        /// <summary>
        /// Edits provided insurance company
        /// </summary>
        /// <returns>Value indicating whether the editing of the insurance company was successfull</returns>
        public bool EditInsuranceCompany(InsuranceCompany insuranceCompany, string insuranceCompanyName, string insuranceCompanyCode)
        {
            bool result = false;

            try
            {
                insuranceCompany.Name = insuranceCompanyName;
                insuranceCompany.Code = insuranceCompanyCode;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided insurance company from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the insurance company was successfull</returns>
        public bool RemoveInsuranceCompany(InsuranceCompany item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
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

        #region Infrastructure

        /// <summary>
        /// Gets non deleted infrastructures from database
        /// </summary>
        /// <returns></returns>
        public IQueryable<Infrastructure> GetInfrastructure()
        {
            IQueryable<Infrastructure> result = null;
            try
            {
                result = db.Infrastructures.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided infrastructure from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the infrastructure was successfull</returns>
        public bool RemoveInfrastructure(Infrastructure item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Creates new infrastructure based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the infrastructure was successfull</returns>
        public bool CreateInfrastructure(string name, string description, decimal costs, decimal margin)
        {
            bool result = false;
            try
            {
                Infrastructure infrastructure = new Infrastructure()
                {
                    Name = name,
                    Description = description,
                    Costs = costs,
                    Margin = margin,
                    IsDeleted = false
                };
                db.Infrastructures.Add(infrastructure);
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Edits provided infrastructure
        /// </summary>
        /// <returns>Value indicating whether the editing of the infrastructure was successfull</returns>
        public bool EditInfrastructure(Infrastructure infrastructure, string name, string description, decimal costs, decimal margin)
        {
            bool result = false;
            try
            {
                infrastructure.Name = name;
                infrastructure.Description = description;
                infrastructure.Costs = costs;
                infrastructure.Margin = margin;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
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

        /// <summary>
        /// Creates new field based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the field was successfull</returns>
        public bool CreateField(string name, string standardNumber, string otherName, FieldType fieldType, Section section,
            string description, List<FieldValue> fieldValues, string question)
        {
            bool result = false;
            try
            {
                Field item = new Field()
                {
                    Name = name,
                    StandardNumber = standardNumber,
                    OtherName = otherName,
                    Description = description,
                    FieldType = fieldType,
                    Section = section,
                    Question = question,
                    IsDeleted = false
                };

                if(fieldType.ID != (int)FieldTypeEnum.Text && fieldType.ID != (int)FieldTypeEnum.LongText)
                    item.FieldValues = fieldValues;

                db.Fields.Add(item);
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Edits provided field
        /// </summary>
        /// <returns>Value indicating whether the editing of the field was successfull</returns>
        public bool EditField(Field field, string name, string standardNumber, string otherName, FieldType fieldType,
            Section section, string description, List<FieldValue> fieldValues, string question)
        {
            bool result = false;

            List<FieldValue> valuesToAdd = fieldValues.Where(x => !field.FieldValues.Select(y => y.Value).Contains(x.Value)).ToList();
            List<FieldValue> valuesToRemove = field.FieldValues.Where(x => !fieldValues.Select(y => y.Value).Contains(x.Value)).ToList();

            try
            {
                foreach (var formQuestion in field.FieldForms.Select(x => x.Question))
                {
                    formQuestion.Value = question;
                }
                //db.Questions.RemoveRange(field.FieldForms.Select(x => x.Question));

                //we have to remove those FieldValueAnswers, which was connected to FieldValues, which will be removed
                if (valuesToRemove.Count > 0)
                {
                    foreach (var item in valuesToRemove)
                    {
                        IQueryable<FilledField> filledFields = db.FilledFields.Where(x => x.FieldValueAnswers.Select(y => y.FieldValueID).Contains(item.ID));

                        foreach (var filledField in filledFields)
                            db.FieldValueAnswers.RemoveRange(filledField.FieldValueAnswers.Where(x => x.FieldValueID == item.ID));
                    }
                    db.FieldValues.RemoveRange(valuesToRemove);
                }

                field.Name = name;
                field.StandardNumber = standardNumber;
                field.OtherName = otherName;
                field.FieldType = fieldType;
                field.Section = section;
                field.Description = description;
                //field.FieldForms = fieldForms;
                field.Question = question;
                field.IsDeleted = false;

                if (fieldType.ID != (int)FieldTypeEnum.Text && fieldType.ID != (int)FieldTypeEnum.LongText
                    && valuesToAdd.Count > 0)
                {
                    foreach (var item in valuesToAdd)
                    {
                        field.FieldValues.Add(item);
                    }
                }

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }


        /// <summary>
        /// Removes provided field from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the field was successfull</returns>
        public bool RemoveField(Field item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }
        #endregion

        #region FilledFields

        /// <summary>
        /// Removes filled fields which belongs to provided user and patient
        /// </summary>
        /// <returns>Value indicating whether the deletion of the filled fields was successfull</returns>
        public void DeleteFilledFields(Patient patient, User user)
        {
            try
            {
                IQueryable<FilledField> filledFields = db.FilledFields.Where(x => x.UserID == user.ID && x.PatientID == patient.ID);
                foreach (var item in filledFields)
                {
                    db.FieldValueAnswers.RemoveRange(item.FieldValueAnswers);
                    if(item.FieldAnswer != null)
                        db.FieldAnswers.Remove(item.FieldAnswer);
                }
                db.FilledFields.RemoveRange(filledFields);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }
        }

        /// <summary>
        /// Removes filled fields which belongs to provided patient
        /// </summary>
        /// <returns>Value indicating whether the deletion of the filled fields was successfull</returns>
        public void DeleteFilledFields(Patient patient)
        {
            try
            {
                IQueryable<FilledField> filledFields = db.FilledFields.Where(x => x.UserID == null && x.PatientID == patient.ID);
                foreach (var item in filledFields)
                {
                    db.FieldValueAnswers.RemoveRange(item.FieldValueAnswers);
                    if (item.FieldAnswer != null)
                        db.FieldAnswers.Remove(item.FieldAnswer);
                }
                db.FilledFields.RemoveRange(filledFields);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }
        }

        /// <summary>
        /// Creates filled fields
        /// </summary>
        /// <param name="filledFields"></param>
        /// <returns>Value indicating whether the creation of the filled fields was successfull</returns>
        public bool CreateFilledFields(List<FilledField> filledFields)
        {
            bool result = true;
            try
            {
                db.FilledFields.AddRange(filledFields);
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
        /// Checks if action with provided name and short name exists in database
        /// </summary>
        /// <returns> Vlue indication whether action with provided name and short name exists in database</returns>
        public bool ActionExists(Model.Action action, string actionName, string shortName)
        {
            bool result = true;

            try
            {
                List<Model.Action> foundedActions = db.Actions.Where(x =>
                (x.Name.Equals(actionName) || x.ShortName.Equals(shortName)) &&
                !x.IsDeleted).ToList();

                if (foundedActions.Count == 0)
                    result = false;
                else if(foundedActions.Count == 1 && foundedActions[0].ID == action.ID)
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
        public bool CreateAction(string actionName, string shortName, string longName, string material,
            int recommendedLength, decimal costs, decimal margin, decimal? insuranceCompanyMargin, InsuranceCompany insuranceCompany, Field field, bool hasSpecification)
        {
            bool result = false;
            try
            {
                Model.Action action = new Model.Action()
                {
                    Name = actionName,
                    ShortName = shortName,
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

        /// <summary>
        /// Edits provided action
        /// </summary>
        /// <returns>Value indicating whether the editing of the action was successfull</returns>
        public bool EditAction(Model.Action action, string actionName, string shortName, string longName, string material, int recommendedLength, decimal costs, decimal margin, decimal? insuranceCompanyMargin, InsuranceCompany insuranceCompany, Field field, bool hasSpecification)
        {
            bool result = false;
            try
            {
                action.Name = actionName;
                action.ShortName = shortName;
                action.LongName = longName;
                action.Material = material;
                action.RecommendedLength = recommendedLength;
                action.Costs = costs;
                action.Margin = margin;
                action.InsuranceCompanyMargin = insuranceCompanyMargin;
                action.InsuranceCompany = insuranceCompany;
                action.Field = field;
                action.HasSpecification = hasSpecification;
                action.IsDeleted = false;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided action from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the action was successfull</returns>
        public bool RemoveAction(Model.Action action)
        {
            bool result = false;

            try
            {
                action.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }
        #endregion

        #region Addresses

        /// <summary>
        /// Creates new address based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the address was successfull</returns>
        public Address CreateAddress(string street, string streetNumber, string city, string zip, string country)
        {
            Address result = null;
            try
            {
                if (!(street == null && streetNumber == null && city == null && zip == null && country == null))
                {
                    result = new Address()
                    {
                        Street = street,
                        StreetNumber = streetNumber,
                        City = city,
                        PostNumber = zip,
                        Country = country
                    };
                    db.Addresses.Add(result);

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
        #endregion

        #region Budgets
        /// <summary>
        /// Gets the budgets of provided patient
        /// </summary>
        /// <returns>IQueryable of patient's budgets</returns>
        public IQueryable<Budget> GetBudgets(Patient patient)
        {
            IQueryable<Budget> result = null;
            try
            {
                if(patient == null)
                    result = db.Budgets.Where(x => !x.IsDeleted);
                else
                    result = db.Budgets.Where(x => !x.IsDeleted && x.PatientID == patient.ID);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Creates new budget based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the budget was successfull</returns>
        public bool CreateBudget(string name, Patient patient, List<BudgetItem> items)
        {
            bool result = false;
            try
            {
                Budget item = new Budget()
                {
                    Name = name,
                    Patient = patient,
                    BudgetItems = items,
                    IsDeleted = false
                };
                db.Budgets.Add(item);
                //db.BudgetItems.AddRange(items);

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Edits provided budget
        /// </summary>
        /// <returns>Value indicating whether the editing of the budget was successfull</returns>
        public bool EditBudget(Budget budget, string name, List<BudgetItem> items)
        {
            bool result = false;
            try
            {
                db.BudgetItems.RemoveRange(budget.BudgetItems);

                budget.Name = name;
                budget.BudgetItems = items;
                budget.IsDeleted = false;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided budget from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the budget was successfull</returns>
        public bool RemoveBudget(Budget item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }
        #endregion

        #region Billing
        /// <summary>
        /// Creates new event bill based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the event bill was successfull</returns>
        public bool CreateEventBill(CalendarEvent calendarEvent, List<EventBillItem> billItems)
        {
            bool result = false;
            try
            {
                EventBill item = new EventBill()
                {
                    CalendarEvent = calendarEvent,
                    EventBillItems = billItems
                };
                db.EventBills.Add(item);
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        #endregion

        #region Contacts
        /// <summary>
        /// Creates new contact based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the contact was successfull</returns>
        public Contact CreateContact(string email, string phone)
        {
            Contact result = null;
            try
            {
                result = new Contact()
                {
                    Email = (email != null) ? email : "",
                    Phone = (phone != null) ? phone : "",
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

        #region CalendarEvents
        /// <summary>
        /// Return list of CalendarEvents from the database
        /// </summary>
        /// <param name="startDate">Start of required time period</param>
        /// <param name="endDate">End of required time period</param>
        /// <returns>List of CalendarEvents between specified dates</returns>
        public IQueryable<CalendarEvent> GetEvents(DateTime startDate, DateTime endDate)
        {
            return db.CalendarEvents.Where(x =>
                x.StartDate >= startDate &&
                x.EndDate <= endDate &&
                !x.IsDeleted);
        }

        /// <summary>
        /// Returns the filtered list of CalendarEvents from the database
        /// </summary>
        /// <param name="filter">Filter to apply</param>
        /// <returns>List of filtered CalendarEvents</returns>
        public IEnumerable<CalendarEvent> GetEvents(CalendarEventFilter filter)
        {
            IEnumerable<CalendarEvent> result;
            result = db.CalendarEvents.Where(x => !x.IsDeleted);

            if (filter.Doctor != null)
                result = result.Where(x => x.Users.Contains(filter.Doctor));
            if (filter.Nurse != null)
                result = result.Where(x => x.Users.Contains(filter.Nurse));
            if (filter.Infrastructure != null)
                result = result.Where(x => x.Infrastructures.Contains(filter.Infrastructure));

            return result;
        }

        /// <summary>
        /// Returns the list of CalendarEvents of specified patient from the database
        /// </summary>
        /// <param name="patientID">The database ID of patient</param>
        /// <returns>List of CalendarEvents of specified patient</returns>
        public IQueryable<CalendarEvent> GetEvents(int patientID)
        {
            return db.CalendarEvents.Where(x => x.PatientID == patientID &&
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
            bool result = true;
            if (newItems.Count == 0)
                return result;

            try
            {
                List<CalendarEvent> newEvents = new List<CalendarEvent>();
                foreach (var item in newItems)
                {
                    var newItem = new CalendarEvent()
                    {
                        GoogleEventID = item.GoogleEventID ?? UnixTimestamp(DateTime.Now),
                        Summary = item.Text,
                        Description = item.Description,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IsSynchronized = true,
                        IsDeleted = item.IsDeleted,
                        IsTemporaryGoogleEvent = true,
                        StateID = (int)EventStateEnum.IsTemporaryGoogleEvent,
                        ColorID = db.CalendarEventColors.First(x => x.EventStateID == (int)EventStateEnum.IsTemporaryGoogleEvent).ID,
                    };
                    newEvents.Add(newItem);
                    item.GoogleEventID = newItem.GoogleEventID;
                }

                db.CalendarEvents.AddRange(newEvents);
                result = SaveChanges();
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

                    //calendarEvent.GoogleEventID = item.GoogleEventID;
                    //calendarEvent.Summary = item.Text;
                    //calendarEvent.Description = item.Description;
                    calendarEvent.StartDate = item.StartDate;
                    calendarEvent.EndDate = item.EndDate;
                    calendarEvent.IsSynchronized = true;
                    calendarEvent.IsDeleted = item.IsDeleted;
                }

                result = SaveChanges();
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        /// <summary>
        /// Creates new calendar event based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the calendar event was successfull</returns>
        public CalendarEvent CreateCalendarEvent(Patient eventPatient, List<User> doctors, List<User> nurses, List<Infrastructure> infrastructures, DateTime eventStartDateTime, decimal eventDuration, string notificationEmails, string eventNote, List<Model.Action> plannedActions, string plannedText, EventState eventState)
        {
            CalendarEvent result = null;

            try
            {
                doctors.AddRange(nurses);
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
                    IsTemporaryGoogleEvent = false,
                    Infrastructures = infrastructures,

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

        /// <summary>
        /// Gets the non deleted calendar events from the databse
        /// </summary>
        /// <returns>IQueryable of non deleted events</returns>
        public IQueryable<CalendarEvent> GetEvents()
        {
            return db.CalendarEvents.Where(x => !x.IsDeleted);
        }

        /// <summary>
        /// Gets the calendar event entity with provided ID
        /// </summary>
        /// <param name="calendarEventID">CalendarEventID</param>
        /// <returns>Calendar event entity with provided ID</returns>
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

        /// <summary>
        /// Gets the calendar event entity with provided GoogleEventID
        /// </summary>
        /// <param name="googleEventID">GoogleEventID</param>
        /// <returns>Calendar event entity with provided GoogleEventID</returns>
        public CalendarEvent GetEvent(string googleEventID)
        {
            CalendarEvent result = null;

            try
            {
                result = db.CalendarEvents.FirstOrDefault(x => x.GoogleEventID == googleEventID);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Edits provided calendar event
        /// </summary>
        /// <returns>Value indicating whether the editing of the calendar event was successfull</returns>
        public bool EditCalendarEvent(CalendarEvent calendarEvent, List<User> doctors, List<User> nurses, List<Infrastructure> infrastructures,
           DateTime startDate, decimal eventDuration,
           string notificationEmails, string eventNote, List<Model.Action> plannedActions, string plannedText, EventState eventState,
           List<DoneActionNotePair> doneActions, string doneText)
        {
            bool result = false;

            try
            {
                doctors.AddRange(nurses);
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
                calendarEvent.Infrastructures = infrastructures;
                calendarEvent.IsSynchronized = false;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Sets the IsSynchronized attribute of the calendar event entity with provided database ID to provided value
        /// </summary>
        /// <param name="databaseEntityID">ID of CalendarEvent entity</param>
        /// <param name="isSynchronized">Wanted value</param>
        /// <returns>Value indicating whether the editing of the calendar event was successfull</returns>
        public bool SetIsSynchronizedStatus(int? databaseEntityID, bool isSynchronized)
        {
            bool result = true;

            try
            {
                CalendarEvent calendarEvent = db.CalendarEvents.FirstOrDefault(x => x.ID == databaseEntityID);

                if (calendarEvent != null)
                    calendarEvent.IsSynchronized = isSynchronized;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided calendar event from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the calendar event was successfull</returns>
        public bool RemoveEvent(CalendarEvent calendarEvent)
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

        #region Formulars
        /// <summary>
        /// Gets the  non deleted formulars from database
        /// </summary>
        /// <returns>IQueryable of non deleted formulars</returns>
        public IQueryable<Form> GetFormulars()
        {
            IQueryable<Form> result = null;
            try
            {
                result = db.Forms.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Creates new formular based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the formular was successfull</returns>

        public bool CreateFormular(string name, List<FieldForm> formFields)
        {
            bool result = false;
            try
            {
                Form item = new Form()
                {
                    Name = name,
                    IsDeleted = false,
                    FieldForms = formFields,
                };
                db.Forms.Add(item);

                //foreach (var formField in formFields)
                //    formField.Form = item;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Edits provided formular
        /// </summary>
        /// <returns>Value indicating whether the editing of the formular was successfull</returns>
        public bool EditFormular(Form form, string name, List<FieldForm> formFields)
        {
            bool result = false;
            try
            {
                form.Name = name;
                form.IsDeleted = false;

                var questionsToRemove = form.FieldForms.Select(x => x.Question);
                db.Questions.RemoveRange(questionsToRemove);
                db.FieldForms.RemoveRange(form.FieldForms);

                form.FieldForms = formFields;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided formular from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the formular was successfull</returns>
        public bool RemoveFormular(Form item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }
        #endregion

        #region Sections
        /// <summary>
        /// Gets the section with provided name
        /// </summary>
        /// <param name="name">Section name</param>
        /// <returns>Section with provided name or null</returns>
        public Section GetSectionByName(string name)
        {
            Section result = null;
            try
            {
                result = db.Sections.FirstOrDefault(x => !x.IsDeleted && x.Name.Equals(name));
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        /// <summary>
        /// Gets non deleted sections from database
        /// </summary>
        /// <returns>IQueryable of non deleted secitons</returns>
        public IQueryable<Section> GetSections()
        {
            IQueryable<Section> result = null;
            try
            {
                result = db.Sections.Where(x => !x.IsDeleted);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Creates new section based on provided informations
        /// </summary>
        /// <returns>Value indicating whether the creation of the section was successfull</returns>
        public bool CreateSection(string name)
        {
            bool result = false;
            try
            {
                Section item = new Section()
                {
                    Name = name,
                    IsDeleted = false
                };
                db.Sections.Add(item);
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Edits provided section
        /// </summary>
        /// <returns>Value indicating whether the editing of the section was successfull</returns>
        public bool EditSection(Section section, string name)
        {
            bool result = false;
            try
            {
                section.Name = name;
                section.IsDeleted = false;

                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        /// <summary>
        /// Removes provided section from database (sets the IsDeleted attribute to true)
        /// </summary>
        /// <returns>Value indicating whether the deletion of the section was successfull</returns>
        public bool RemoveSection(Section item)
        {
            bool result = false;

            try
            {
                item.IsDeleted = true;
                result = SaveChanges();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
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
        /// Gets field types stored in database
        /// </summary>
        /// <returns>Field types</returns>
        public IEnumerable<FieldType> GetFieldTypes()
        {
            IQueryable<FieldType> result = null;
            try
            {
                result = db.FieldTypes;
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

        /// <summary>
        /// Gets the event state from database
        /// </summary>
        /// <param name="state">Wanted state</param>
        /// <returns>Event state</returns>
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

        #region Private methods
        /// <summary>
        /// Creates unix time stamp from provided DateTime value
        /// </summary>
        /// <returns>Unix time stamp</returns>
        private string UnixTimestamp(DateTime dateTime)
        {
            return ((Int32)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
        }

        /// <summary>
        /// Gets the calendar event end date value
        /// </summary>
        /// <returns>Calendar event end date value</returns>
        private DateTime GetEventEndDate(DateTime eventStartDateTime, decimal eventDuration)
        {
            return eventStartDateTime.AddMinutes((double)eventDuration);
        }

        /// <summary>
        /// Creates summary for calendar event based on patient name and planned actions
        /// </summary>
        /// <returns>Calendar event summary</returns>
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

        /// <summary>
        /// Gets the calendar event executed actions
        /// </summary>
        /// <returns>Calendar event executed actions</returns>
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
                result = new List<CalendarEventExecutedAction>();
                BasicMessagesHandler.LogException(e);
            }

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
        #endregion
    }
}
