using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerSystem
{
    /// <summary>
    /// Represents logging system.
    /// </summary>
    internal class LoggingSystem
    {
        /// <summary>
        /// Import to file.
        /// </summary>
        /// <param name="FilePath">FilePath.</param>
        public void ImportFromFile(string FilePath)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                var logMessage = reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Export to file.
        /// </summary>
        /// <param name="FilePath">FilePath.</param>
        /// <param name="logMessage">List of log message.</param>
        public void ExportToFile(string FilePath, List<Boiler>logMessage) 
        { 
            using (StreamWriter writer = new StreamWriter(FilePath,true))
            {
                using (CsvWriter csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvwriter.WriteRecords(logMessage);
                }
            }
        }
    }
}
