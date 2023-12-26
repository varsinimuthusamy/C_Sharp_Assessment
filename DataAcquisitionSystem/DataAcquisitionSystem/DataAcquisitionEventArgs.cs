using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represnts Data Acquisition EventArgs.
    /// </summary>
    public class DataAcquisitionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes an instance of <see cref="DataAcquisitionEventArgs"/> class.
        /// </summary>
        public DataAcquisitionEventArgs() 
        {
            AcquisitionDatas = new List<AcquisitionData>();
        }

        /// <summary>
        /// Represents AcquisitionDatas.
        /// </summary>
        public List<AcquisitionData> AcquisitionDatas { get; set; }
    }
}
