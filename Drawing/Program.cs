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
        static void SetOpacity(ConsoleKey key, ref int)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    opacity = 2;
            }
        }
        static void Write(int opacity)
        {
            switch (opacity)
            {
                case 1:
                    Console.Write("█");
                    break;
                case 2:
                    Console.Write("▓");
                    break;
                case 3:
                    Console.Write("▒");
                    break;
                case 4:
                    Console.Write("░");
                    break;
            }
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
                        Console.CursorTop--;
                        if (Console.CapsLock) 
                        { 
                            Console.Write("█");
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
                            Console.Write("█");
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
                            Console.Write("█");
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
                            Console.Write("█");
                            Console.CursorLeft--;
                        }
                    }
                    break;
            }
        }
        static void KeyDistro(ConsoleKey key)
        {
            ConsoleKey[] arrowKeys = {ConsoleKey.UpArrow,ConsoleKey.RightArrow,ConsoleKey.DownArrow,ConsoleKey.LeftArrow};
            ConsoleKey[] functionKeys = {ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4};
            if (arrowKeys.Contains(key))
            {
                MoveCursor(key);
            }
            if (functionKeys.Contains(key))
            {
                SetOpacity(key,ref opacity);
            }

        }
        static void Main(string[] args)
        {
            int opacity = 1;
            BorderCreating();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            while (true)
            {
                KeyDistro(Console.ReadKey(true).Key);
            }
        }
    }
}
