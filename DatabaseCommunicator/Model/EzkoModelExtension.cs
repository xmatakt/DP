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
            return Name + " [" + Code + "]";
        }
    }

    public partial class Field
    {
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class FieldValue
    {
        public override string ToString()
        {
            return Value;
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

    public partial class Budget
    {
        public string PdfFile()
        {
            return Patient.Name + "_" + Patient.Surname + "_rozpocet_" + ID + ".pdf";
        }
    }

    public partial class Form
    {
        public string PdfFile()
        {
            return Name + "_" + ID + ".pdf";
        }
    }

    public partial class CalendarEvent
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(StartDate.ToString("dd.MM. HH:mm"));
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
                //if (Patient == null)
                //    return "";
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

    public partial class Address
    {
        public string FullAddress
        {
            get
            {
                return Street + " " + StreetNumber + ", " + City + ", " + Country;
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
                case (int)Enums.EventStateEnum.IsTemporaryGoogleEvent:
                    return "Event vytvorený v google kalendári";
                default:
                    return "Neznámy stav";
            }
        }
    }

    public partial class Sex
    {
        public override string ToString()
        {
            switch (ID)
            {
                case (int)Enums.SexEnum.Man:
                    return "Muž";
                case (int)Enums.SexEnum.Woman:
                    return "Žena";
                case (int)Enums.SexEnum.Unknown:
                    return "neudané";
                default:
                    return "neudané";
            }
        }
    }

    public partial class FieldType
    {
        public override string ToString()
        {
            switch (ID)
            {
                case (int)Enums.FieldTypeEnum.Text:
                    return "Text";
                case (int)Enums.FieldTypeEnum.LongText:
                    return "Dlhý text";
                case (int)Enums.FieldTypeEnum.RadioBox:
                    return "Možnosti Radio";
                case (int)Enums.FieldTypeEnum.SelectBox:
                    return "Možnosti Select";
                case (int)Enums.FieldTypeEnum.CheckBox:
                    return "CheckBox";
                default:
                    return "Neznámy typ";
            }
        }
    }

    public partial class Section
    {
        public override string ToString()
        {
            return Name;
        }
    }
}
