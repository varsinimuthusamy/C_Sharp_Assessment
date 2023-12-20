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

        public void ApplicationInitialization(BoilerOperation boilerOperation)
        {
            Console.WriteLine($"{boilerOperation.boiler.Status}\n{boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
            ExportToFile(boilerOperation.GetAllBoilers());
        }
        /// <summary>
        /// Start boiler.
        /// </summary>
        public void StartBoilerSequence(BoilerOperation boilerOperation)
        {
            if (Boiler.Switch == true)
            {
                boilerOperation.PrePurgeCycle();
                ExportToFile(boilerOperation.GetAllBoilers());
                Console.WriteLine($"{boilerOperation.boiler.Status}\n{boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
                boilerOperation.IgnitionPhase();
                ExportToFile(boilerOperation.GetAllBoilers());
                Console.WriteLine($"{boilerOperation.boiler.Status}\n{boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
                boilerOperation.OperationalCycle();
                ExportToFile(boilerOperation.GetAllBoilers());
                Console.WriteLine($"{boilerOperation.boiler.Status} \n {boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
            }
            else
            {
                ErrorMessage("Please close the interlock switch");
                return;
            }
        }

        /// <summary>
        /// Get file Path
        /// </summary>
        public string GetFilePath()
        {
            while (true)
            {
                Console.WriteLine("Enter Filename for status log");
                string filePath = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(filePath))
                {
                    return filePath;
                }
                ErrorMessage("File path must not be empty");
            }
        }

        /// <summary>
        /// Log status to File.
        /// </summary>
        public void ExportToFile(List<Boiler> boilers)
        {
            try
            {
                LoggingSystem loggingSystem = new LoggingSystem();
                loggingSystem.ExportToFile(GetFilePath(), boilers);
            }
            catch (Exception e)
            {
                ErrorMessage($"{e.Message}");
            }
        }

        /// <summary>
        /// View Log message.
        /// </summary>
        public void ViewLog()
        {
            try
            {
                LoggingSystem loggingSystem = new LoggingSystem();
                string filePath = GetFilePath();
                if (File.Exists(filePath))
                {
                    string logMessage = loggingSystem.ImportFromFile(filePath);
                    Console.WriteLine(logMessage);
                }
                else
                {
                    Console.WriteLine("File doesn't exist.Please enter valid file name.");
                }
            }
            catch (Exception e)
            {
                ErrorMessage($"{e.Message}");
            }
        }

        /// <summary>
        /// Toggle Switch.
        /// </summary>
        public void ToggleSwitch(BoilerOperation boilerOperation)
        {
            Console.WriteLine($"Interlocked switch togged is {Boiler.Switch}");
            while (true)
            {
                Console.WriteLine("Please click 'T' to toggle the switch");
                if(Console.ReadLine() == "T")
                {
                    boilerOperation.ToggleSwitch();
                    Console.WriteLine($"Interlocked switch togged is {Boiler.Switch}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter T to toggle");
                }
            }
        }
        /// <summary>
        /// Represents error message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
