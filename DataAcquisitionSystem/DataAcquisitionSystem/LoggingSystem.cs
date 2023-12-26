using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents logging system.
    /// </summary>
    public class LoggingSystem
    {
        /// <summary>
        /// Serialize data.
        /// </summary>
        /// <param name="acquisitionData">.acquisitionData.</param>
        public void SaveToFile(string message)
        {
            string fileName = "LogFile.txt";

            while (Utility.FileIsLocked(fileName, FileAccess.Write))
            {
            }
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
