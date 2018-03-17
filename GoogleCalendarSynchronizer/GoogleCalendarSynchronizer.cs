using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using ExceptionHandler;
using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using System.Net;

namespace GoogleCalendarSynchronizer
{
    /// <summary>
    /// Class for synchronizing WinForms calendar events with Google Calendar Events
    /// - provides inserting, deleting and updating WinForms Calendar Events
    /// - provides inserting, deleting and updating Google Calendar Events
    /// </summary>
    public class GoogleCalendarSynchronizer
    {
        private static string[] scopes = { CalendarService.Scope.Calendar };
        private static string applicationName = "EZKO";
        private string userName;
        private string calendarID;
        private CalendarService service;
        private System.Windows.Forms.Calendar.Calendar calendar;

        #region Public methods

        /// <summary>
        /// Creates new instance of GoogleCalendarSynchronizer class
        /// </summary>
        /// <param name="calendar">System.Windows.Forms.Calendar calendar</param>
        /// <param name="userName">User name for Google Calendar API</param>
        /// <param name="calendarID">Google calendar ID</param>
        public GoogleCalendarSynchronizer(System.Windows.Forms.Calendar.Calendar calendar, string userName, string calendarID = null)
        {
            this.calendar = calendar;
            this.userName = userName;
            this.calendarID = calendarID ?? "primary";

            try
            {
                service = GetGoogleService();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť Google Calendar Service", e);
            }
        }

        public GoogleCalendarSynchronizer(string userName, string calendarID = null)
        {
            this.userName = userName;
            this.calendarID = calendarID ?? "primary";

            try
            {
                service = GetGoogleService();
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť Google Calendar Service", e);
            }
        }

        /// <summary>
        /// Method to obtain google calendar events from required time period
        /// </summary>
        /// <param name="startDate">Beginig of required time periond</param>
        /// <param name="endDate">End of required time periond</param>
        /// <returns>Returns list of google events saved as winforms calendar items</returns>
        public List<CalendarItem> GetGoogleCalendarItems(DateTime startDate, DateTime endDate)
        {
            List<CalendarItem> result = new List<CalendarItem>();
            try
            {
                // Define parameters of request.
                EventsResource.ListRequest request = service.Events.List(calendarID);
                request.TimeMin = startDate;
                request.TimeMax = endDate;
                request.ShowDeleted = false;
                request.SingleEvents = false;
                //request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.Updated;

                // List events
                Events events = request.Execute(); 
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        if (eventItem.Start.DateTime.HasValue || eventItem.End.DateTime.HasValue)
                        {
                            var resultItem = new CalendarItem(calendar, eventItem.Start.DateTime.Value, eventItem.End.DateTime.Value,
                            eventItem.Summary, eventItem.Description, false);
                            resultItem.GoogleEventID = eventItem.Id;
                            result.Add(resultItem);
                            //service.Events.Delete("vul8uj8500f0oimq588h9n8v90@group.calendar.google.com", eventItem.Id).Execute();    
                        }
                    }
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa načítať udalosti z Google kalendára", e);
                result = new List<CalendarItem>();
            }

            return result;
        }

        public List<CalendarItem> GetDbCalendarItems(EzkoController ezkoController, DateTime startDate, DateTime endDate)
        {
            List<CalendarItem> result = new List<CalendarItem>();
            try
            {
                foreach (var eventItem in ezkoController.GetEvents().Where(x => x.StartDate >= startDate && x.EndDate <= endDate && x.IsSynchronized))
                {
                    var resultItem = new CalendarItem(calendar, eventItem.StartDate, eventItem.EndDate,
                        eventItem.Summary, eventItem.Description, eventItem.IsDeleted);
                    resultItem.GoogleEventID = eventItem.GoogleEventID;
                    resultItem.DatabaseEntityID = eventItem.ID;
                    result.Add(resultItem);
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa načítať udalosti z Google kalendára", e);
                result = new List<CalendarItem>();
            }

            return result;
        }

        /// <summary>
        /// Creates new Google Calendat events and uploads them on the internet
        /// </summary>
        /// <param name="newItems"></param>
        /// <returns>Returs value indicating wheter the upload was successfull</returns>
        public bool UploadEvents(List<CalendarItem> newItems)
        {
            bool result = true;
            if (newItems.Count == 0)
                return result;

            try
            {
                foreach (var item in newItems)
                {
                    if (item.IsDeleted)
                        continue;
                    Event calendarEvent = new Event();

                    calendarEvent.Id = item.GoogleEventID;
                    calendarEvent.Summary = item.Text;
                    //calendarEvent.Location = "Mytna 36, Bratislava, Slovensko";
                    calendarEvent.Description = item.Description;

                    DateTime startDateTime = item.StartDate;
                    EventDateTime start = new EventDateTime();
                    start.DateTime = startDateTime;
                    //start.TimeZone = "Europe/Prague";
                    calendarEvent.Start = start;

                    DateTime endDateTime = item.EndDate;
                    EventDateTime end = new EventDateTime();
                    end.DateTime = endDateTime;
                    //end.TimeZone = "Europe/Prague";
                    calendarEvent.End = end;

                    //String[] recurrence = new String[] { "RRULE:FREQ=DAILY;COUNT=2" };
                    //calendarEvent.Recurrence = recurrence;

                    //EventAttendee[] attendees = new EventAttendee[] {
                    //    new EventAttendee()
                    //    {
                    //        Email = "motii131@gmail.com"
                    //    }
                    //};
                    //calendarEvent.Attendees = attendees;

                    //EventReminder[] reminderOverrides = new EventReminder[]
                    //{
                    //    new EventReminder()
                    //    {
                    //        Method = "email",
                    //        Minutes = 10
                    //    },
                    //    new EventReminder()
                    //    {
                    //        Method = "popup",
                    //        Minutes = 10
                    //    }
                    //};

                    //Event.RemindersData reminders = new Event.RemindersData();
                    //reminders.UseDefault = false;
                    //reminders.Overrides = reminderOverrides;

                    //calendarEvent.Reminders = reminders;

                    service.Events.Insert(calendarEvent, calendarID).Execute();
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť Google eventy", e);
            }

            return result;
        }

        public bool UploadEvent(CalendarItem newEvent, EzkoController ezkoController)
        {
            if (!CheckForInternetConnection())
                return false;

            bool result = false;

            try
            {
                if (!newEvent.IsDeleted)
                {
                    Event calendarEvent = new Event();

                    calendarEvent.Id = newEvent.GoogleEventID;
                    calendarEvent.Summary = newEvent.Text;
                    //calendarEvent.Location = "Mytna 36, Bratislava, Slovensko";
                    calendarEvent.Description = newEvent.Description;

                    DateTime startDateTime = newEvent.StartDate;
                    EventDateTime start = new EventDateTime();
                    start.DateTime = startDateTime;
                    //start.TimeZone = "Europe/Prague";
                    calendarEvent.Start = start;

                    DateTime endDateTime = newEvent.EndDate;
                    EventDateTime end = new EventDateTime();
                    end.DateTime = endDateTime;
                    //end.TimeZone = "Europe/Prague";
                    calendarEvent.End = end;

                    service.Events.Insert(calendarEvent, calendarID).Execute();
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť Google event", e);
            }

            if(result)
                result = ezkoController.SetIsSynchronizedStatus(newEvent.DatabaseEntityID, true);

            return result;
        }

        public bool UploadEvent(int databaseEntityID, string googleEventId,string summary, string description, DateTime startDate, DateTime endDate, EzkoController ezkoController)
        {
            if (!CheckForInternetConnection())
                return false;

            bool result = false;

            try
            {
                    Event calendarEvent = new Event();

                    calendarEvent.Id = googleEventId;
                    calendarEvent.Summary = summary;
                    calendarEvent.Description = description;

                    DateTime startDateTime = startDate;
                    EventDateTime start = new EventDateTime();
                    start.DateTime = startDateTime;
                    calendarEvent.Start = start;

                    DateTime endDateTime = endDate;
                    EventDateTime end = new EventDateTime();
                    end.DateTime = endDateTime;
                    calendarEvent.End = end;

                    service.Events.Insert(calendarEvent, calendarID).Execute();
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť Google event", e);
            }

            if (result)
                result = ezkoController.SetIsSynchronizedStatus(databaseEntityID, true);

            return result;
        }

        /// <summary>
        /// Updates/deletes existing Google Calendat events
        /// </summary>
        /// <param name="updatedItems"></param>
        /// <returns>Returs value indicating wheter the update/delete was successfull</returns>
        public bool UpdateEvents(List<CalendarItem> updatedItems)
        {
            bool result = true;
            if (updatedItems.Count == 0)
                return result;

            try
            {
                foreach (var item in updatedItems)
                {
                    Event googleEvent = service.Events.Get(calendarID, item.GoogleEventID).Execute();

                    if (item.IsDeleted)
                        service.Events.Delete(calendarID, googleEvent.Id).Execute();
                    else
                    {
                        googleEvent.Summary = item.Text;
                        googleEvent.Description = item.Description;
                        googleEvent.Start.DateTime = item.StartDate;
                        googleEvent.End.DateTime = item.EndDate;
                        service.Events.Update(googleEvent, calendarID, googleEvent.Id).Execute();
                    }
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        public bool UpdateEvent(CalendarItem updatedItem, EzkoController ezkoController)
        {
            if (!CheckForInternetConnection())
                return false;

            bool result = true;
            if (updatedItem == null)
                return result;

            try
            {
                Event googleEvent = service.Events.Get(calendarID, updatedItem.GoogleEventID).Execute();

                if (updatedItem.IsDeleted)
                    service.Events.Delete(calendarID, googleEvent.Id).Execute();
                else
                {
                    googleEvent.Summary = updatedItem.Text;
                    googleEvent.Description = updatedItem.Description;
                    googleEvent.Start.DateTime = updatedItem.StartDate;
                    googleEvent.End.DateTime = updatedItem.EndDate;
                    service.Events.Update(googleEvent, calendarID, googleEvent.Id).Execute();
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            if (result)
                result = ezkoController.SetIsSynchronizedStatus(updatedItem.DatabaseEntityID, true);

            return result;
        }

        public bool UpdateEvent(int databaseEntityID, string googleEventId, string summary, string description, DateTime startDate, DateTime endDate, bool isDeleted, EzkoController ezkoController)
        {
            if (!CheckForInternetConnection())
                return false;

            bool result = true;

            try
            {
                Event googleEvent = service.Events.Get(calendarID, googleEventId).Execute();

                if (isDeleted)
                    service.Events.Delete(calendarID, googleEvent.Id).Execute();
                else
                {
                    googleEvent.Summary = summary;
                    googleEvent.Description = description;
                    googleEvent.Start.DateTime = startDate;
                    googleEvent.End.DateTime = endDate;
                    service.Events.Update(googleEvent, calendarID, googleEvent.Id).Execute();
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            if (result)
                result = ezkoController.SetIsSynchronizedStatus(databaseEntityID, true);

            return result;
        }

        public bool SynchronizeEvents(EzkoController ezkoController)
        {
            if (!CheckForInternetConnection())
                return false;

            List<CalendarItem> googleItems = GetGoogleCalendarItems(DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(12));
            List<CalendarItem> dbItems = GetDbCalendarItems(ezkoController, DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(12));

            List<CalendarItem> dbUpdateItems = new List<CalendarItem>();
            List<CalendarItem> dbUploadItems = new List<CalendarItem>();

            foreach (var googleItem in googleItems)
            {
                CalendarEvent dbItem = ezkoController.GetEvent(googleItem.GoogleEventID);

                if (dbItem != null)
                {
                    // if event dates were changed in Google Calendar, transfer changes onto database items
                    if (!dbItem.IsDeleted && dbItem.IsSynchronized)
                    {
                        CalendarItem updatedItem = new CalendarItem(calendar, dbItem.StartDate, dbItem.EndDate,
                            dbItem.Summary, dbItem.Description, dbItem.IsDeleted);
                        updatedItem.GoogleEventID = dbItem.GoogleEventID;

                        if (!googleItem.Equals(updatedItem))
                        {
                            updatedItem.StartDate = googleItem.StartDate;
                            updatedItem.EndDate = googleItem.EndDate;
                            updatedItem.DatabaseEntityID = dbItem.ID;

                            dbUpdateItems.Add(updatedItem);
                        }
                    }
                }
                // if there is not such an item in database, create new one - only temporary item which tells to doctor or nurse
                // to create new event from EZKO application
                else
                {
                    dbUploadItems.Add(googleItem);
                }
            }

            //we need to synchronize unsynchronized events (event created/updated during no internet connection)
            if (!SynchronizeUnsynchronizedEvents(ezkoController))
                BasicMessagesHandler.ShowErrorMessage("Počas synchronizácie udalostí v s Google kalendárom sa vyskytla");

            //we need to mark db events as deleted if they were deleted from google calendar
            MarkAsDeleted(DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(12), dbItems, dbUpdateItems);

            bool dbUploadResult = ezkoController.AddCalendarEvents(dbUploadItems);
            bool dbUpdateResult = ezkoController.UpdateCalendarEvents(dbUpdateItems);

            if (!dbUploadResult)
                BasicMessagesHandler.ShowErrorMessage("Počas ukldadania nových udalostí do databázy sa vyskytla chyba");
            if (!dbUpdateResult)
                BasicMessagesHandler.ShowErrorMessage("Počas synchronizácie udalostí v databáze sa vyskytla chyba");

            return dbUploadResult && dbUpdateResult;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Creates new google CalendarService used to CRUD operations
        /// </summary>
        /// <returns></returns>
        private CalendarService GetGoogleService()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/ezko.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    userName,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName,
            });

            return service;
        }

        private bool SynchronizeUnsynchronizedEvents(EzkoController ezkoController)
        {
            bool result = true;
            try
            {
                List<CalendarEvent> unsynchronizedEvents = ezkoController.GetEvents().Where(x => !x.IsSynchronized).ToList();

                if (unsynchronizedEvents.Count <= 0)
                    return result;

                EventsResource.ListRequest request = service.Events.List(calendarID);
                request.TimeMin = DateTime.Now.AddMonths(-6);
                request.TimeMax = DateTime.Now.AddMonths(12);
                request.ShowDeleted = false;
                request.SingleEvents = false;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.Updated;

                Events googleEvents = request.Execute();

                foreach (var unsynchronizedEvent in unsynchronizedEvents)
                {
                    if(unsynchronizedEvent.GoogleEventID != null)
                    {
                        if(googleEvents.Items.FirstOrDefault(x => x.Id == unsynchronizedEvent.GoogleEventID) == null)
                        {
                            UploadEvent(unsynchronizedEvent.ID, unsynchronizedEvent.GoogleEventID, unsynchronizedEvent.Summary,
                                unsynchronizedEvent.Description, unsynchronizedEvent.StartDate, unsynchronizedEvent.EndDate, ezkoController);
                        }
                        else
                        {
                            UpdateEvent(unsynchronizedEvent.ID, unsynchronizedEvent.GoogleEventID, unsynchronizedEvent.Summary, unsynchronizedEvent.Description,
                                unsynchronizedEvent.StartDate, unsynchronizedEvent.EndDate, unsynchronizedEvent.IsDeleted, ezkoController);
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.LogException(ex);
                result = false;
            }

            return result;
        }

        private void MarkAsDeleted(DateTime startDate, DateTime endDate, List<CalendarItem> dbItems, List<CalendarItem> updateItems)
        {
            try
            {
                // Define parameters of request.
                EventsResource.ListRequest request = service.Events.List(calendarID);
                request.TimeMin = startDate;
                request.TimeMax = endDate;
                request.ShowDeleted = false;
                request.SingleEvents = false;
                //request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.Updated;

                // List events
                Events events = request.Execute();

                foreach (var item in dbItems)
                {
                    if(events.Items.FirstOrDefault(x => x.Id == item.GoogleEventID) == null)
                    {
                        item.IsDeleted = true;

                        if (!updateItems.Contains(item))
                            updateItems.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri synchronizácií Google kalendára.", e);
            }
        }


        private bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                BasicMessagesHandler.ShowInformationMessage("Ste offline. Synchronizácia s Google kalendárom neprebehla.");
                return false;
            }
        }
        #endregion
    }
}
