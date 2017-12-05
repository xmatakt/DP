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
