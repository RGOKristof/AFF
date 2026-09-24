namespace Calculator
{
    internal class Program
    {
        static void showErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Digit-by-digit check: is the whole string a valid number (optional leading '-',
        // digits, at most one ',')? No TryParse involved.
        static bool isValidNumber(string input, out string errorText)
        {
            int index = 0;
            bool hasDigit = false;
            bool hasComma = false;

            if (input.Length > 0 && input[0] == '-')
            {
                index = 1;
            }

            while (index < input.Length)
            {
                char currentChar = input[index];

                if (char.IsDigit(currentChar))
                {
                    hasDigit = true;
                }
                else if (currentChar == ',')
                {
                    if (hasComma)
                    {
                        errorText = "Csak egy tizedesvessző szerepelhet a számban!";
                        return false;
                    }
                    hasComma = true;
                }
                else
                {
                    errorText = "Rossz bevitel!";
                    return false;
                }

                index++;
            }

            if (!hasDigit)
            {
                errorText = "Rossz bevitel!";
                return false;
            }

            errorText = "";
            return true;
        }

        // Manual string -> decimal conversion (no decimal.Parse / TryParse).
        // Only called after isValidNumber already confirmed the format is correct.
        static decimal parseDecimal(string input)
        {
            bool isNegative = false;
            int index = 0;

            if (input[0] == '-')
            {
                isNegative = true;
                index = 1;
            }

            decimal integerPart = 0;
            while (index < input.Length && char.IsDigit(input[index]))
            {
                integerPart = integerPart * 10 + (input[index] - '0');
                index++;
            }

            decimal fractionPart = 0;
            if (index < input.Length && input[index] == ',')
            {
                index++;
                decimal placeValue = 0.1m;
                while (index < input.Length && char.IsDigit(input[index]))
                {
                    fractionPart += (input[index] - '0') * placeValue;
                    placeValue *= 0.1m;
                    index++;
                }
            }

            decimal value = integerPart + fractionPart;
            return isNegative ? -value : value;
        }

        static decimal takingOperandus(int numOfOperandus, char currentOperator)
        {
            string failed = "";
            while (true)
            {
                Console.Clear();

                if (failed != "")
                {
                    showErrorMessage(failed);
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

                string operandusInput = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(operandusInput))
                {
                    failed = "Rossz bevitel!";
                    continue;
                }

                if (!isValidNumber(operandusInput, out string errorText))
                {
                    failed = errorText;
                    continue;
                }

                decimal parsed = parseDecimal(operandusInput);

                if (parsed == 0 && currentOperator == '/')
                {
                    failed = "Nem lehet 0-át/0-val osztani!";
                    continue;
                }

                return parsed;
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Calculator";

            char currentOperator = '+';
            string failedOperator = "";

            while (true)
            {
                Console.Clear();

                if (failedOperator != "")
                {
                    showErrorMessage(failedOperator);
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

                string operatorInput = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(operatorInput))
                {
                    currentOperator = '+';
                    break;
                }

                if (operatorInput == "+" || operatorInput == "-" || operatorInput == "*" || operatorInput == "/")
                {
                    currentOperator = operatorInput[0];
                    break;
                }

                failedOperator = "Rossz bevitel!";
            }

            decimal currentOperandusOne = takingOperandus(1, currentOperator);
            decimal currentOperandusTwo = takingOperandus(2, currentOperator);
            decimal result;

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

            Console.Clear();
            Console.WriteLine(result);
        }
    }
}