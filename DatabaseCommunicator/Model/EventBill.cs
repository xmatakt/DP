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
    
    public partial class EventBill
    {
        public EventBill()
        {
            this.EventBillItems = new HashSet<EventBillItem>();
        }
    
        public int ID { get; set; }
        public int CalendarEventID { get; set; }
    
        public virtual CalendarEvent CalendarEvent { get; set; }
        public virtual ICollection<EventBillItem> EventBillItems { get; set; }
    }
}
