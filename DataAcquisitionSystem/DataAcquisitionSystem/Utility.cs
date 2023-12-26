using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// Represents utility functions.
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Represents Start of Acquisition.
        /// </summary>
        public void StartAcquisition()
        {
          
        }

        /// <summary>
        /// Configure compliance module.
        /// </summary>
        public void ConfigureComplianceModule()
        {
            Console.WriteLine("Please add Compliance limits for following parameters :" +
                              "\n1.Current\n2.Temperature");

            int userChoice;
            while(true)
            {
                userChoice = IsvalidInput();
                if (userChoice == 1 || userChoice == 2)
                {
                    break;
                }
                MessageColor("Please choose any of given options.", false);
            }

            Parameters parameter;
            if(userChoice == 1)
            {
                parameter = Parameters.Current; 
            }
            else
            {
                parameter = Parameters.Temperature;
            }
        }

        /// <summary>
        /// Gets valid value from user.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Returns valid input.</returns>
        public static int IsvalidInput()
        {
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int validInput))
                {
                        return validInput;
                }

                MessageColor("Please choose positive integers!", false);
            }
        }

        /// <summary>
        /// Check valid option,
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns valid option.</returns>
        public static int IsValidOption(int value)
        {
            while (true)
            {
               
            }
        }

        /// <summary>
        /// Represents color of message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="success">Succcess.</param>
        public static void MessageColor(string message, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"\n{message}\n");
            Console.ResetColor();
        }
    }
}
