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
    
    public partial class Contact
    {
        public Contact()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public int ID { get; set; }
        public string Email { get; set; }
        public string AlternativeEmail { get; set; }
        public string Facebook { get; set; }
        public string Phone { get; set; }
        public string AlternativePhone { get; set; }
    
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
