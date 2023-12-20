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
    internal class Boiler
    {
        /// <summary>
        /// Switch.
        /// </summary>
        public static bool Switch {  get; set; } = false;

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

        public Boiler (string status, DateTime timestamp, string message) 
        { 
            Timestamp = timestamp;
            Message = message;
            Status = status;
        }
    }
}
