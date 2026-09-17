namespace CalculatorV2
{
    internal class Program
    {
        static void Color(string colorName = "reset")
        {
            switch (colorName.ToLower())
            {
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "reset":
                    Console.ResetColor();
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        static void PrintError(string errorMessage)
        {
            Color("red");
            Console.WriteLine(errorMessage);
            Color();
        }
        static void PrintWarning(string errorMessage)
        {
            Color("yellow");
            Console.WriteLine(errorMessage);
            Color();
        }

        static char TakeOperator(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input == null)
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Calculator";

            Color("Cyan");
            Console.WriteLine("Welcome to the calculator!");
            Color("yellow");
            Console.WriteLine("Press anything to begin.");
            Color();
            Console.ReadKey(false);

            //Globals
            List<decimal> memory = new List<decimal>();

            char currentOperator;
            decimal currentOperandusOne;
            decimal currentOperandusTwo;

            bool running = true;
            while (running)
            {
                Console.Clear();

                TakeOperator("");

            }


        }
    }
}
