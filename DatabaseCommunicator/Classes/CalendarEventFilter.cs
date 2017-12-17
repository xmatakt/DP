using DatabaseCommunicator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
    public class CalendarEventFilter
    {
        public User Doctor { get; set; }
        public User Nurse { get; set; }
        public Infrastructure Infrastructure { get; set; }
    }
}
