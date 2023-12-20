using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerSystem
{
    /// <summary>
    /// Implements User menu.
    /// </summary>
    internal class UserMenu
    {
        public List<Boiler> boilers;
        public UserMenu() 
        { 
            boilers = new List<Boiler>();
        }

        /// <summary>
        /// Start boiler.
        /// </summary>
        public void StartBoilerSequence(BoilerOperation boilerOperation,LoggingSystem loggingSystem)
        {
            if(Boiler.Switch == true)
            {
                Boiler boiler = boilerOperation.PrePurgeCycle();
                boilers.Add(boiler);
                Console.WriteLine($"{boiler.Status}\n{boiler.Message}\nElapsed Time : {DateTime.Now - boiler.Timestamp}");
                boiler = boilerOperation.IgnitionPhase();
                boilers.Add(boiler);
                Console.WriteLine($"{boiler.Status}\n{boiler.Message}\nElapsed Time : {DateTime.Now - boiler.Timestamp}");
                boiler = boilerOperation.OperationalCycle();
                boilers.Add(boiler);
                Console.WriteLine($"{boiler.Status}\n{boiler.Message}\nElapsed Time : {DateTime.Now - boiler.Timestamp}");
            }
            else
            {
                ErrorMessage("Please close the interlock switch");
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LogtoFile()
        {

        }

        /// <summary>
        /// Represents error message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
