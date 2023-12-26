using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents JSON format.
    /// </summary>
    public class JSONFormat
    {
        /// <summary>
        /// Initializes an intance of <see cref="JSONFormat"/> class.
        /// </summary>
        public JSONFormat() 
        {
            Parameters = new List<AcquisitionData>();
        }

        /// <summary>
        /// Represents rate.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Represents Parameters.
        /// </summary>
        public List<AcquisitionData> Parameters { get; set; }
    }
}
