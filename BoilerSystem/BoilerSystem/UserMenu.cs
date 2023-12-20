using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BoilerSystem
{
    /// <summary>
    /// Implements User menu.
    /// </summary>
    internal class UserMenu
    {
        private static int _count = 1;

        private System.Timers.Timer aTimer = new System.Timers.Timer();

        /// <summary>
        /// File path.
        /// </summary>
        private string _filePath { get; set; }

        /// <summary>
        /// Initialize Application.
        /// </summary>
        /// <param name="boilerOperation">boilerOperation.</param>
        public void ApplicationInitialization(BoilerOperation boilerOperation)
        {
            _filePath = GetFilePath();
            ExportToFile(boilerOperation.GetAllBoilers());
            Console.WriteLine($"{boilerOperation.boiler.Status}\n{boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
        }

        /// <summary>
        /// Set timer.
        /// </summary>
        public void SetTimer()
        {
            aTimer.Interval = 1000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            aTimer.AutoReset = true;
            while (_count <= 10) ;
            aTimer.Enabled = false;
        }

        /// <summary>
        /// Start boiler.
        /// </summary>
        public void StartBoilerSequence(BoilerOperation boilerOperation)
        {
            if (Boiler.Switch == true)
            {
                boilerOperation.PrePurgeCycle();
                SetTimer();
                ExportToFile(boilerOperation.GetAllBoilers());
                Console.WriteLine($"\nStatus : {boilerOperation.boiler.Status}\nMessage : {boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}\n");
                boilerOperation.IgnitionPhase();
                _count = 0;
                SetTimer();
                ExportToFile(boilerOperation.GetAllBoilers());
                Console.WriteLine($"\nStatus : {boilerOperation.boiler.Status}\nMessage : {boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}\n");
                boilerOperation.OperationalCycle();
                _count = 0;
                SetTimer();
                ExportToFile(boilerOperation.GetAllBoilers());
                Console.WriteLine($"\nStatus : {boilerOperation.boiler.Status}\nMessage : {boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}\n");
            }
            else
            {
                ErrorMessage("Please close the interlock switch.");
                return;
            }
        }

        /// <summary>
        /// Elapsed time.
        /// </summary>
        /// <param name="source">source.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (_count <= 10)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine(_count++);
            }
        }

        /// <summary>
        /// Stops boiler sequence.
        /// </summary>
        /// <param name="boilerOperation">boilerOperation.</param>
        public void StopBoilerSequence(BoilerOperation boilerOperation)
        {
            if (Boiler.Switch == true)
            {
                boilerOperation.StopBoiler();
                Console.WriteLine($"\nStatus : {boilerOperation.boiler.Status}\nMessage : {boilerOperation.boiler.Message}\nElapsed Time : {DateTime.Now - boilerOperation.boiler.Timestamp}");
            }
            else
            {
                ErrorMessage("Boiler Sequence is not yet started.");
            }
        }

        /// <summary>
        /// Get file Path
        /// </summary>
        public string GetFilePath()
        {
            while (true)
            {
                Console.Write("Enter Filename for status log : ");
                string filePath = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(filePath))
                {
                    return filePath;
                }
                ErrorMessage("File path must not be empty.");
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
                loggingSystem.ExportToFile(_filePath, boilers);
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
                    Console.WriteLine($"\n{logMessage}");
                }
                else
                {
                    ErrorMessage("File doesn't exist.Please enter valid file name.");
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
            Console.WriteLine($"\nInterlocked switch togged is {Boiler.Switch}");
            while (true)
            {
                Console.Write("Please click 'T' to toggle the switch : ");
                if (Console.ReadLine() == "T")
                {
                    boilerOperation.ToggleSwitch();
                    Console.WriteLine($"\nInterlocked switch togged is {Boiler.Switch}.");
                    break;
                }
                else
                {
                    ErrorMessage("Please enter T to toggle.");
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
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
