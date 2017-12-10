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

        #region public

        /// <summary>
        /// Creates new instance of GoogleCalendarSynchronizer class
        /// </summary>
        /// <param name="calendar">User name for Google Calendar API</param>
        /// <param name="userName">User name for Google Calendar API</param>
        /// <param name="calendarID">System.Windows.Forms.Calendar calendar</param>
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

        /// <summary>
        /// Method to obtain google calendar events from required time period
        /// </summary>
        /// <param name="startDate">Beginig of required time periond</param>
        /// <param name="endDate">End of required time periond</param>
        /// <returns>Returns list of google events saved as winforms calendar items</returns>
        public List<CalendarItem> GetCalendarItems(DateTime startDate, DateTime endDate)
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

        public bool UploadEvent(CalendarItem newEvent)
        {
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
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa vytvoriť Google event", e);
            }

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

        public bool UpdateEvent(CalendarItem updatedItem)
        {
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

            return result;
        }

        #endregion

        #region private
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
#endregion
    }
}
