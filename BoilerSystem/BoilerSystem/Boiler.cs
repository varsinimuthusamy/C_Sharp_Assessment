using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerSystem
{
    /// <summary>
    /// Represents boiler.
    /// </summary>
    public class Boiler
    {
        /// <summary>
        /// Switch.
        /// </summary>
        public static bool Switch { get; set; } = false;

        /// <summary>
        /// Boiler Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Log message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Instializes an intance of Boiler.
        /// </summary>
        /// <param name="status">Status.</param>
        /// <param name="timestamp">TimeStamp.</param>
        /// <param name="message">Message.</param>
        public Boiler(string status, DateTime timestamp, string message)
        {
            Timestamp = timestamp;
            Message = message;
            Status = status;
        }

        /// <summary>
        /// Deep copy of boiler.
        /// </summary>
        /// <param name="boiler"></param>
        public Boiler(Boiler boiler)
        {
            Timestamp = boiler.Timestamp;
            Message = boiler.Message;
            Status = boiler.Status;
        }
    }
}
