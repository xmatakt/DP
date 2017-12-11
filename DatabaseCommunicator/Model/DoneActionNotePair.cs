using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Model
{
    /// <summary>
    /// Class used in VisitUserControl to store done actions and note
    /// in paired manner
    /// </summary>
    public class DoneActionNotePair
    {
        public DatabaseCommunicator.Model.Action DoneAction { get; set; }
        public string ActionNote { get; set; }
    }
}
