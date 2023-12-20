using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerSystem
{
    /// <summary>
    /// Performs boiler operation.
    /// </summary>
    internal class BoilerOperation
    {

        /// <summary>
        /// Represents boiler.
        /// </summary>
        private readonly Boiler _boiler;

        /// <summary>
        /// Initializes the instance of BoilerOperation.
        /// </summary>
        public BoilerOperation()
        {
            new Boiler("Lockout", DateTime.Now, "Boiler iniatialized");
        }

        /// <summary>
        /// Represents boiler initialization.
        /// </summary>
        /// <param name="status">Boiler status.</param>
        /// <param name="timestamp">Timestamp.</param>
        /// <param name="message">Message.</param>
        public void BoilerInitialization()
        {
            Boiler boiler = new Boiler("Lockout", DateTime.Now, "Boiler iniatialized");
        }

        /// <summary>
        /// Represents PrePurgeCycle.
        /// </summary>
        public Boiler PrePurgeCycle()
        {
            _boiler.Timestamp = DateTime.Now;
            Thread.Sleep(1000);
            _boiler.Status = "Pre-Purge";
            _boiler.Message = "Pre-purge completed";
            return _boiler;
        }

        /// <summary>
        /// Represents Ignition Cycle.
        /// </summary>
        public Boiler IgnitionPhase()
        {
            _boiler.Timestamp = DateTime.Now;
            Thread.Sleep(1000);
            _boiler.Status = "Ignition";
            _boiler.Message = "Ignition completed";
             return _boiler;
        }

        /// <summary>
        /// Represents Operational cycle.
        /// </summary>
        public Boiler OperationalCycle()
        { 
            _boiler.Timestamp = DateTime.Now;
            Thread.Sleep(1000);
            _boiler.Status = "Operational";
            _boiler.Message = "Boiler now operational";
            return _boiler;
        }

        /// <summary>
        /// Toggle switch.
        /// </summary>
        public void ToggleSwitch()
        {
            Boiler.Switch = !Boiler.Switch;
        }
    }
}
