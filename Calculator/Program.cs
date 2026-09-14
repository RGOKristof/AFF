#pragma warning disable CS8600
namespace Calculator
{
    internal class Program
    {
        static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static decimal TakingOperandus(int numOfOperandus, char currentOperator)
        {
            string failed = "";
            while (true)
            {
                Console.Clear();

                if (failed != "")
                {
                    ErrorMessage(failed);
                }

                switch (numOfOperandus)
                {
                    case 1:
                        Console.Write("Első szám: ");
                        break;
                    case 2:
                        Console.Write("Második szám: ");
                        break;
                }

                string operandusInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(operandusInput))
                {
                    failed = "Rossz bevitel!";
                    continue;
                }

                if (decimal.TryParse(operandusInput, out decimal parsed))
                {
                    if (Decimal.Parse(operandusInput) == 0 && currentOperator == '/')
                    {
                        failed = "Nem lehet 0-át/0-val osztani!";
                        continue;
                    }
                    return parsed;
                }

                failed = "Rossz bevitel!";
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Calculator";
            char currentOperator = '+';
            decimal currentOperandusOne;
            decimal currentOperandusTwo;
            decimal result;

            bool failed = false;
            while (true)
            {
                Console.Clear();

                if (failed)
                {
                    ErrorMessage("Rossz bevitel!");
                }

                Console.Write("Válassz operátort(");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("+, -, *, /");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]: ");

                string operatorInput = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(operatorInput))
                {
                    currentOperator = '+';
                    break;
                }

                if (operatorInput == "+" || operatorInput == "-" || operatorInput == "*" || operatorInput == "/")
                {
                    currentOperator = char.Parse(operatorInput);
                    break;
                }
                else
                {
                    failed = true;
                    continue;
                }
            }

            currentOperandusOne = TakingOperandus(1, currentOperator);
            currentOperandusTwo = TakingOperandus(2, currentOperator);

            switch (currentOperator)
            {
                case '+':
                    result = currentOperandusOne + currentOperandusTwo;
                    break;

                case '-':
                    result = currentOperandusOne - currentOperandusTwo;
                    break;

                case '*':
                    result = currentOperandusOne * currentOperandusTwo;
                    break;

                case '/':
                    result = currentOperandusOne / currentOperandusTwo;
                    break;

                default:
                    result = 0;
                    break;

            }

            Console.WriteLine(result);


        }
    }
}
