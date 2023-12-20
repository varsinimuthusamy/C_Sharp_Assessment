using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerSystem
{
    /// <summary>
    /// UserChoice.
    /// </summary>
    public enum UserChoice
    {
        /// <summary>
        /// Toggle switch.
        /// </summary>
        ToggleSwitch = 1,

        /// <summary>
        /// Start boiler sequence.
        /// </summary>
        StartBoilerSequence = 2,

        /// <summary>
        /// End boiler sequence.
        /// </summary>
        EndBoilerSequence = 3,

        /// <summary>
        /// View Application.
        /// </summary>
        ViewApplication = 4,

        /// <summary>
        /// Exit.
        /// </summary>
        Exit = 0,
    }
}
