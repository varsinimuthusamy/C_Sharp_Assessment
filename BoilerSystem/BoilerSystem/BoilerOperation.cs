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
        private readonly List<Boiler> boilers;
        /// <summary>
        /// Represents boiler.
        /// </summary>
        public readonly Boiler boiler;

        /// <summary>
        /// Initializes the instance of BoilerOperation.
        /// </summary>
        public BoilerOperation()
        {
            new Boiler("Lockout", DateTime.Now, "Boiler iniatialized");
            new List<Boiler>();
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
        public void PrePurgeCycle()
        {
            boiler.Timestamp = DateTime.Now;
            Thread.Sleep(1000);
            boiler.Status = "Pre-Purge";
            boiler.Message = "Pre-purge completed";
            boilers.Add(boiler);
        }

        /// <summary>
        /// Represents Ignition Cycle.
        /// </summary>
        public void IgnitionPhase()
        {
            boiler.Timestamp = DateTime.Now;
            Thread.Sleep(1000);
            boiler.Status = "Ignition";
            boiler.Message = "Ignition completed";
             boilers.Add(boiler);
        }

        /// <summary>
        /// Represents Operational cycle.
        /// </summary>
        public void OperationalCycle()
        { 
            boiler.Timestamp = DateTime.Now;
            Thread.Sleep(1000);
            boiler.Status = "Operational";
            boiler.Message = "Boiler now operational";
            boilers.Add(boiler);
        }

        /// <summary>
        /// Toggle switch.
        /// </summary>
        public void ToggleSwitch()
        {
            Boiler.Switch = !Boiler.Switch;
        }

        /// <summary>
        /// Deep cop Boilers.
        /// </summary>
        /// <returns>Returns list of boilers.</returns>
        public List<Boiler> GetAllBoilers()
        {
            var copiedBoilers = boilers.ConvertAll<Boiler>(boiler => new Boiler(boiler));
            return copiedBoilers;
        }
    }
}
