using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents user menu.
    /// </summary>
    public enum UserMenu
    {
        /// <summary>
        ///  Represents start of acquisition System.
        /// </summary>
        StartAcquisitionSystem = 1,

        /// <summary>
        ///  Represents end of acquisition System.
        /// </summary>
        EndAcquisitionSystem = 2,

        /// <summary>
        ///  Represents configuration of acquisition System.
        /// </summary>
        ConfigureComplianceModule = 3,

        /// <summary>
        ///  Represents refresh configuration.
        /// </summary>
        RefreshConfiguration = 4,

        /// <summary>
        ///  Represents Exit of acquisition System application.
        /// </summary>
        Exit = 0,
    }
}
