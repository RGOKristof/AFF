//Console.Title = "Üdvözlő";
//Console.Write("add meg a neved");
//string name = Console.ReadLine();
//Console.WriteLine($"Szia {name}!");
//Console.WindowHeight;
//Console.WindowWidth;
//Console.SetCursorPosition( 0, 0 );
//var position = Console.GetCursorPosition();
//position.Top , position.Left
//Console.WindowLeft();
//Console.WindowTop();
//Console.ForegroundColor = ConsoleColor.Green;
//Console.BackgroundColor = ConsoleColor.Green;
//Thread.Sleep(milisec);
//█▓▒░
//╔═╗
//║ ║
//╚═╝
using System.Drawing;
using System.Security.Principal;
using System.Text;

namespace Drawing
{
    internal class Program
    {
        static void CreateBorder()
        {
            Console.SetCursorPosition(0, 0);
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            StringBuilder border = new StringBuilder();
            border.Append("╔");
            for (int x = 0; x < windowWidth - 2; x++)
            {
                border.Append("═");
            }
            border.Append("╗");
            for (int y = 0; y < windowHeight - 2; y++)
            {
                border.Append("║");
                for (int x = 0; x < windowWidth - 2; x++)
                {
                    border.Append(" ");
                }
                border.Append("║");
            }
            border.Append("╚");
            for (int x = 0; x < windowWidth - 2; x++)
            {
                border.Append("═");
            }
            border.Append("╝");
            Console.Write(border.ToString());
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
        }
        static void Write(char character)
        {
            Console.Write(character);
            Console.CursorLeft--;
        }
        static void Main(string[] args)
        {
            ConsoleKey[] arrowKeys = { ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow };
            ConsoleKey[] functionKeys = { ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4 };
            ConsoleKey[] foregroundColorKeys = { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9 };
            ConsoleKey[] backgroundColorKeys = { ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9 };
            ConsoleKey[] colorFunctionKeys = { ConsoleKey.Add, ConsoleKey.Subtract, ConsoleKey.OemPlus, ConsoleKey.OemMinus };

            char character = '█';

            CreateBorder();
            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                if (arrowKeys.Contains(pressedKey))
                {
                    int fromTop = Console.GetCursorPosition().Top;
                    int fromLeft = Console.GetCursorPosition().Left;
                    switch (pressedKey)
                    {
                        case ConsoleKey.UpArrow:
                            if (fromTop > 1)
                            {
                                Console.CursorTop--;
                                if (Console.CapsLock)
                                {
                                    Write(character,foregroundColor,backgroundColor);
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (fromLeft < Console.WindowWidth - 2)
                            {
                                Console.CursorLeft++;
                                if (Console.CapsLock)
                                {
                                    Write(character, foregroundColor, backgroundColor);
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (fromTop < Console.WindowHeight - 2)
                            {
                                Console.CursorTop++;
                                if (Console.CapsLock)
                                {
                                    Write(character, foregroundColor, backgroundColor);
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (fromLeft > 1)
                            {
                                Console.CursorLeft--;
                                if (Console.CapsLock)
                                {
                                    Write(character, foregroundColor, backgroundColor);
                                }
                            }
                            break;
                    }
                }
                if (functionKeys.Contains(pressedKey))
                {
                    switch (pressedKey)
                    {
                        case ConsoleKey.F1:
                            character = '█';
                            break;
                        case ConsoleKey.F2:
                            character = '▓';
                            break;
                        case ConsoleKey.F3:
                            character = '▒';
                            break;
                        case ConsoleKey.F4:
                            character = '░';
                            break;
                    }
                }
                if (foregroundColorKeys.Contains(pressedKey))
                {
                    switch (pressedKey)
                    {
                        case ConsoleKey.D1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case ConsoleKey.D2:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case ConsoleKey.D3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case ConsoleKey.D4:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case ConsoleKey.D5:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case ConsoleKey.D6:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case ConsoleKey.D7:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case ConsoleKey.D8:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case ConsoleKey.D9:
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                    }
                }
                if (backgroundColorKeys.Contains(pressedKey))
                {
                    switch (pressedKey)
                    {
                        case ConsoleKey.NumPad1:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        case ConsoleKey.NumPad2:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case ConsoleKey.NumPad3:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case ConsoleKey.NumPad4:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case ConsoleKey.NumPad5:
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            break;
                        case ConsoleKey.NumPad6:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                        case ConsoleKey.NumPad7:
                            Console.BackgroundColor = ConsoleColor.White;
                            break;
                        case ConsoleKey.NumPad8:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case ConsoleKey.NumPad9:
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }
                if (colorFunctionKeys.Contains(pressedKey))
                {
                    switch (pressedKey)
                    {
                        case ConsoleKey.Add:
                            break;
                        case ConsoleKey.Subtract:
                            break;
                        case ConsoleKey.OemPlus:
                            break;
                        case ConsoleKey.OemMinus:
                            break;
                    }

                }
                if (ConsoleKey.Spacebar == pressedKey)
                {
                    Write(character, foregroundColor, backgroundColor);
                }
                if (ConsoleKey.Backspace == pressedKey)
                {
                    Write('█', ConsoleColor.Black, ConsoleColor.Black);
                }
            }
        }
    }
}
