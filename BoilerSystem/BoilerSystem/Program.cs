namespace BoilerSystem
{
    /// <summary>
    /// This is driver class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// UserChoice.
        /// </summary>
        public enum UserChoice
        {
            ToggleSwitch = 1,
            StartBoilerSequence = 2,
            EndBoilerSequence = 3,
            ViewApplication = 4,
            Exit = 0,
        }

        /// <summary>
        /// This is driver method.
        /// </summary>
        public static void Main()
        {
            BoilerOperation boilerOperation = new BoilerOperation();
            Console.WriteLine("Welcome to Boiler controller");
            while (true)
            {
                Console.WriteLine("Enter the choice");
                if (!int.TryParse(Console.ReadLine(), out int validChoice))
                {
                    Console.WriteLine("Enter only integers");
                    continue;
                }
                switch ((UserChoice)validChoice)
                {
                    case UserChoice.ToggleSwitch:

                        break;
                    case UserChoice.StartBoilerSequence:
                        break;
                    case UserChoice.EndBoilerSequence:
                        break;
                    case UserChoice.ViewApplication:
                        break;
                    case UserChoice.Exit:
                        Console.WriteLine("Thankyou for using boiler controller!");
                        return;
                    default:
                        Console.WriteLine("Please enter any of the given options");
                        break;
                }
            }
        }
    }
}