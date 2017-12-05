//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseCommunicator.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CalendarEvent
    {
        public CalendarEvent()
        {
            this.CalendarEventExecutedActions = new HashSet<CalendarEventExecutedAction>();
            this.Infrastructures = new HashSet<Infrastructure>();
            this.Actions = new HashSet<Action>();
            this.Users = new HashSet<User>();
        }
    
        public int ID { get; set; }
        public int ColorID { get; set; }
        public string GoogleEventID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool IsSynchronized { get; set; }
        public bool IsDeleted { get; set; }
        public int PatientID { get; set; }
        public string NotificationEmails { get; set; }
        public string PlanedActionText { get; set; }
        public string ExecutedActionText { get; set; }
        public int StateID { get; set; }
    
        public virtual EventState EventState { get; set; }
        public virtual CalendarEventColor CalendarEventColor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<CalendarEventExecutedAction> CalendarEventExecutedActions { get; set; }
        public virtual ICollection<Infrastructure> Infrastructures { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
