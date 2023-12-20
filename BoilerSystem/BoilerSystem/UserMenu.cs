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
            ExportToFile(boilerOperation.GetAllBoilers());
            Console.WriteLine($"{boilerOperation.boiler.Status}\n{boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
        }
        /// <summary>
        /// Start boiler.
        /// </summary>
        public void StartBoilerSequence(BoilerOperation boilerOperation, LoggingSystem loggingSystem)
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
        public void ViewLog()
        {
            try
            {
                LoggingSystem loggingSystem = new LoggingSystem();
                if (File.Exists(GetFilePath()))
                {
                    string logMessage = loggingSystem.ImportFromFile(GetFilePath());
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
        public void ToggleSwitch()
        {
            Console.WriteLine("Please enter close");
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
