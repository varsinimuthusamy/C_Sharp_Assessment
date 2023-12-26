namespace DataAcquisitionSystem
{
    /// <summary>
    /// This is driver class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This is driver method.
        /// </summary>
        static void Main()
        {
            DataAcquisitionModule dataAcquisitionModule = new DataAcquisitionModule();
            ComplianceModule complianceModule = new ComplianceModule();
            Utility utility = new Utility();
            Console.WriteLine("Welcome to acquisition system!");
            while (true)
            {
                Console.WriteLine("Choose any options:\n1.StartAcquisitionSystem\n" +
                    "2.EndAcquisitionSystem\n" +
                    "3.ConfigureComplianceModule\n" +
                    "4. RefreshConfiguration\n" +
                    "5.Exit\n");
                int validInput = Utility.IsvalidInput();
                switch ((UserMenu)validInput)
                {
                    case UserMenu.StartAcquisitionSystem:
                        utility.StartAcquisition(dataAcquisitionModule, complianceModule);
                        break;
                    case UserMenu.EndAcquisitionSystem:
                        utility.EndAcquisition(dataAcquisitionModule, complianceModule);
                        break;
                    case UserMenu.ConfigureComplianceModule:
                        utility.ConfigureComplianceModule(complianceModule);
                        break;
                    case UserMenu.RefreshConfiguration:
                        utility.Refresh(dataAcquisitionModule);
                        break;
                    case UserMenu.Exit:
                        Utility.MessageColor("Thankyou for using our application");
                        return;
                    default:
                        Utility.MessageColor("Please choose any of the given options", false);
                        break;
                }
            }
        }
    }
}