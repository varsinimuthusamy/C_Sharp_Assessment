﻿using System;
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
            using (StreamWriter writer = new StreamWriter("LogFile.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
