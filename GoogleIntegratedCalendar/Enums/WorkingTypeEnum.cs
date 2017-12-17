using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKO.Enums
{
    /// <summary>
    /// Enum to specify which type of action to use 
    ///     If Creting: creates new  database entities in database after validation is successfull
    ///     If Editing: updates database entities in database after validation is successfull
    ///     If Recreting: creates new entities in database based on existing ones after validation is successfull
    /// </summary>
    public enum WorkingTypeEnum
    {
        Creating = 1,
        Editing = 2,
        Recreating = 3,
        CreatingFromGoogleEvent = 4,
    }
}
