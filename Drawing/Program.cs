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
using System.Security.Principal;
using System.Text;

namespace Drawing
{
    internal class Program
    {
        static void BorderCreating()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            StringBuilder border = new StringBuilder();
            for (int x = 0; x < windowWidth; x++)
            {
                for (int y = 0; y < windowHeight; y++)
                {
                    if (y == 0 && x == 0) { border.Append('╔'); }
                    else if (y == 0 && x < windowWidth) { border.Append('═'); }
                    else if (y == 0 && (x >= windowWidth)) { border.Append('╗'); }
                }
            }
            Console.Write(border.ToString());
        }
        static void MoveCursor(ConsoleKey key)
        {
            int fromTop = Console.GetCursorPosition().Top;
            int fromLeft = Console.GetCursorPosition().Left;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (fromTop > 1)
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (fromLeft < Console.WindowWidth - 2)
                    {
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (fromTop < Console.WindowHeight - 2)
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (fromLeft > 1)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                    break;

            }
        }
        static void Main(string[] args)
        {
            BorderCreating();
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            while (true)
            {
                MoveCursor(Console.ReadKey(false).Key);
            }
        }
    }
}
