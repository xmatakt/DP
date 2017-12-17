using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Enums
{
    /// <summary>
    /// Enum to map data from EventState table
    /// </summary>
    public enum EventStateEnum
    {
        Planned = 1,
        Done = 2,
        Cancelled = 3,
        Payed = 4,
        IsTemporaryGoogleEvent = 5
    }
}
