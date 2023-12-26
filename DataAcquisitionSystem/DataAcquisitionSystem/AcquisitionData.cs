﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents Acquisition Data.
    /// </summary>
    internal class AcquisitionData : EventArgs
    {
        /// <summary>
        /// Represents Parameter.
        /// </summary>
        public Parameters Parameter { get; set; }

        /// <summary>
        /// Represnts higher limit of parameter.
        /// </summary>
        public int HighLimit { get; set; }

        /// <summary>
        /// Represnts lower limit of parameter.
        /// </summary>
        public int LowLimit { get; set; }
    }
}
