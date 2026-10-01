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
        static void BorderCreating()
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
        }
        static void Write(char character,ConsoleColor color)
        {
            Console.Write(character);
        }
        static void Main(string[] args)
        {
            ConsoleKey[] arrowKeys = { ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow };
            ConsoleKey[] functionKeys = { ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4 };
            char character = '█';
            ConsoleColor color = ConsoleColor.White;
            BorderCreating();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
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
                                    Write(character,color);
                                    Console.CursorLeft--;
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (fromLeft < Console.WindowWidth - 2)
                            {
                                Console.CursorLeft++;
                                if (Console.CapsLock)
                                {
                                    Write(character, color);
                                    Console.CursorLeft--;
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (fromTop < Console.WindowHeight - 2)
                            {
                                Console.CursorTop++;
                                if (Console.CapsLock)
                                {
                                    Write(character, color);
                                    Console.CursorLeft--;
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (fromLeft > 1)
                            {
                                Console.CursorLeft--;
                                if (Console.CapsLock)
                                {
                                    Write(character, color);
                                    Console.CursorLeft--;
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
                if (ConsoleKey.Spacebar == pressedKey)
                {
                    Write(character, color);
                    Console.CursorLeft--;
                }
            }
        }
    }
}
