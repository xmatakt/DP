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
    
    public partial class FieldValueAnswer
    {
        public FieldValueAnswer()
        {
            this.FilledFields = new HashSet<FilledField>();
        }
    
        public int ID { get; set; }
        public int FieldValueID { get; set; }
        public bool IsChecked { get; set; }
    
        public virtual FieldValue FieldValue { get; set; }
        public virtual ICollection<FilledField> FilledFields { get; set; }
    }
}
