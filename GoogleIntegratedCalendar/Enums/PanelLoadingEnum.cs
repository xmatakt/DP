using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKO.Enums
{
    /// <summary>
    /// Enum used in MainForm to define which panel has to be loaded
    /// </summary>
    public enum PanelLoadingEnum
    {
        LoadingDashboardPanel = 1,
        LoadingAmbulantionPanel = 2,
        LoadingPatientsPanel = 3,
        LoadingAdministrationPanel = 4,
        LoadAll = 5,
    }
}
