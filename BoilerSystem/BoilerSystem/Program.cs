namespace BoilerSystem
{
    /// <summary>
    /// This is driver class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This is driver method.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to Boiler controller!");
            BoilerOperation boilerOperation = new BoilerOperation();
            UserMenu userMenu = new UserMenu();
            userMenu.ApplicationInitialization(boilerOperation);
            while (true)
            {
                Console.WriteLine("\n1.Toogle Switch\n2.Start boiler\n3.End boiler\n4.View log\n0.Exit");
                Console.WriteLine("Enter the choice");
                if (!int.TryParse(Console.ReadLine(), out int validChoice))
                {
                    Console.WriteLine("Enter only integers");
                    continue;
                }
                switch ((UserChoice)validChoice)
                {
                    case UserChoice.ToggleSwitch:
                        userMenu.ToggleSwitch(boilerOperation);
                        break;
                    case UserChoice.StartBoilerSequence:
                        userMenu.StartBoilerSequence(boilerOperation);
                        break;
                    case UserChoice.EndBoilerSequence:
                        userMenu.StopBoilerSequence(boilerOperation);
                        break;
                    case UserChoice.ViewApplication:
                        userMenu.ViewLog();
                        break;
                    case UserChoice.Exit:
                        Console.WriteLine("\nThankyou for using boiler controller!");
                        return;
                    default:
                        Console.WriteLine("\nPlease enter any of the given options");
                        break;
                }
            }
        }
    }
}