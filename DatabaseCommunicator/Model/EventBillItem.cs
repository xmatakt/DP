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
    
    public partial class EventBillItem
    {
        public int ID { get; set; }
        public int EventBillID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
        public decimal Discount { get; set; }
    
        public virtual EventBill EventBill { get; set; }
    }
}