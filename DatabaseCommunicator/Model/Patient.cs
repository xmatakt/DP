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
    
    public partial class Patient
    {
        public Patient()
        {
            this.Budgets = new HashSet<Budget>();
            this.CalendarEvents = new HashSet<CalendarEvent>();
            this.FilledFields = new HashSet<FilledField>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string BIFO { get; set; }
        public string LegalRepresentative { get; set; }
        public string TitleBefore { get; set; }
        public string TitleAfter { get; set; }
        public string BirthNumber { get; set; }
        public Nullable<int> InsuranceCompanyID { get; set; }
        public Nullable<int> SexID { get; set; }
        public string Employment { get; set; }
        public string Note { get; set; }
        public Nullable<int> AddressID { get; set; }
        public int ContactID { get; set; }
        public string RootDirectoryPath { get; set; }
        public string AvatarImagePath { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<FilledField> FilledFields { get; set; }
    }
}
