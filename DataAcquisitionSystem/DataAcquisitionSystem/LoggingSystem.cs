using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents logging system.
    /// </summary>
    internal class LoggingSystem
    {
        /// <summary>
        /// Serialize data.
        /// </summary>
        /// <param name="acquisitionData">.acquisitionData.</param>
        public void SaveToFile(string message)
        {
            using (StreamWriter writer = new StreamWriter("LogFile.txt", true))
            {
                writer.WriteLine();
            }
        }
    }
}
