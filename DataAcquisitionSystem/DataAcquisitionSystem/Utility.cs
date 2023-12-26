using System.Timers;

namespace DataAcquisitionSystem
{
    
    /// <summary>
    /// Represents utility functions.
    /// </summary>
    public class Utility
    {
        private GenerateData _generateData;
        /// <summary>
        /// Represents Start of Acquisition.
        /// </summary>
        public void StartAcquisition(DataAcquisitionModule dataAcquisitionModule, ComplianceModule complianceModule)
        {
            try
            {
                Console.WriteLine("Data Acquisition started");
                dataAcquisitionModule.LoadJSON();
                dataAcquisitionModule.RefreshEvent += complianceModule.CheckValidLimits;
                _generateData = new GenerateData(complianceModule, dataAcquisitionModule);
                MessageColor("Data Generated logging to LogFile.txt..");
            }
            catch (Exception ex)
            {
                LoggingSystem loggingSystem = new LoggingSystem();
                Console.WriteLine($"{ex.Message}");
                loggingSystem.SaveToFile($"{ex.Message}");
            }
        }

        /// <summary>
        /// Display details.
        /// </summary>
        public static void DisplayConfigurationDetails(ComplianceModule complianceModule)
        {
            foreach(AcquisitionData data in complianceModule.GetAcquisitionDatas())
            {
                MessageColor($"parameter : {data.Parameter} HighLimit : {data.HighLimit} LowLimit : {data.LowLimit}\n");
            }
        }

        /// <summary>
        /// Represents end of acquisition system.
        /// </summary>
        /// <param name="dataAcquisitionModule">DataAcquisitionModule.</param>
        /// <param name="complianceModule">ComplianceModule.</param>
        public void EndAcquisition(DataAcquisitionModule dataAcquisitionModule, ComplianceModule complianceModule)
        {
            if( _generateData != null )
            {
                _generateData.StopTimer();
                MessageColor("Data Acquisition Ended");
                return;
            }
            MessageColor("Acquistion system is already stopped",false);
        }

        /// <summary>
        /// Refresh the Acquisition model.
        /// </summary>
        /// <param name="dataAcquisitionModule">Data Acquisition Module.</param>
        public void Refresh(DataAcquisitionModule dataAcquisitionModule, ComplianceModule complianceModule)
        {
            dataAcquisitionModule.OnRefresh();
        }

        /// <summary>
        /// Configure compliance module.
        /// </summary>
        public void ConfigureComplianceModule(DataAcquisitionModule dataAcquisitionModule)
        {
            LoggingSystem loggingSystem = new LoggingSystem();
            Console.WriteLine("Please add Compliance limits for following parameters :" +
                              "\n1.Current\n2.Temperature");

            int userChoice;
            while (true)
            {
                userChoice = IsvalidInput();
                if (userChoice == 1 || userChoice == 2)
                {
                    break;
                }
                MessageColor("Please choose any of given options.", false);
            }

            Parameters parameter;
            if (userChoice == 1)
            {
                parameter = Parameters.Current;
            }
            else
            {
                parameter = Parameters.Temperature;
            }
            Console.WriteLine($"Please enter high limit of {parameter}");
            int maxValue = IsvalidInput();
            Console.WriteLine($"Please enter Low limit of {parameter}");
            int minValue = IsvalidInput();
            dataAcquisitionModule.SaveJSON(new AcquisitionData(parameter, maxValue, minValue));
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
                if (int.TryParse(Console.ReadLine(), out int validInput))
                {
                    return validInput;
                }

                MessageColor("Please choose positive integers!", false);
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

        public static bool FileIsLocked(string filename, FileAccess file_access)
        {
            // Try to open the file with the indicated access.
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, file_access);
                fs.Close();
                return false;
            }
            catch (IOException)
            {
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
