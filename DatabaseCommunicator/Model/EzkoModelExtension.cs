using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Model
{
    public partial class InsuranceCompany
    {
        public override string ToString()
        {
            return Code;
        }
    }

    public partial class Field
    {
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class Patient
    {
        public string FullName
        {
            get { return Name + " " + Surname; }
        }

        public override string ToString()
        {
            return FullName;
        }
    }

    public partial class User
    {
        public override string ToString()
        {
            return Login;
        }
    }

    public partial class Action
    {
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class CalendarEvent
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(StartDate.ToString("dd.MM. hh:mm"));
            stringBuilder.Append(" / ");
            stringBuilder.Append(((int)((EndDate - StartDate)).TotalMinutes).ToString());
            stringBuilder.Append(" / ");
            stringBuilder.Append(EventSummary);

            return stringBuilder.ToString();
        }

        public string EventSummary
        {
            get
            {
                string result = Patient.FullName;

                if (Actions.Count > 0)
                    result += " / ";

                bool isFirst = true;
                foreach (var item in Actions)
                {
                    if (isFirst)
                    {
                        result += item.Name;
                        isFirst = false;
                    }
                    else
                        result += ", " + item.Name;
                }

                return result;
            }
        }

        public string Details
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Telefón: " + Patient.Contact.Phone);
                stringBuilder.AppendLine("Email: " + Patient.Contact.Email);
                stringBuilder.AppendLine("Poznámka: " + Description);

                return stringBuilder.ToString();
            }
        }
    }


    public partial class EventState
    {
        public override string ToString()
        {
            switch(ID)
            {
                case (int) Enums.EventStateEnum.Planned:
                return "Plánovaná";
                case (int)Enums.EventStateEnum.Done:
                    return "Uskutočnená";
                case (int)Enums.EventStateEnum.Cancelled:
                    return "Zrušená";
                case (int)Enums.EventStateEnum.Payed:
                    return "Uhradená";
                default:
                    return "Neznámy stav";
            }
        }
    }
}
