#pragma warning disable CA1416 // Validate platform compatibility
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
using System.Xml;

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
        static void OpenMenu()
        {
            int buttonWidth = 15;
            int buttonHeight = 3;
            int marginSide = 5;
            int marginBottom = 1;
            string[] buttons = ["Mentés", "Betöltés", "Új", "Kilépés"];
            int[] LTP = [ (Console.WindowWidth - (buttonWidth + marginSide)) / 2 , (Console.WindowHeight - buttons.Length * (buttonHeight + marginBottom)) / 2 ];

            // Itt lekéne menteni az eddigi rajzot ramba

            // Majd kirajzolni a menut

            Console.Clear();
            Console.SetCursorPosition(LTP[0], LTP[1]);
            for (int i = 0; i < 4; i++)
            {
            Console.SetCursorPosition(LTP[0], LTP[1]);
            Console.Write("┌──────────────────┐");
            Console.Write("│                  │");
            Console.Write("└──────────────────┘");
            }
        }
        static string[][] SaveToMemory()
        {
            string[][] image = [["0","0","▒","ConsoleColor.Red","ConsoleColor.Blue"]];

            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    string pixelX = x.ToString();
                    string pixelY = y.ToString();
                    //string pixelChar = Console.Read();
                    image.Append([]);
                    Console.CursorLeft++;
                }
                Console.CursorTop++;
            }
            return image;
            
        }
        static void Write(char character, ConsoleColor BGColor, ConsoleColor FGColor)
        {
            Console.BackgroundColor = BGColor;
            Console.ForegroundColor = FGColor;
            Console.Write(character);
            Console.CursorLeft--;
            
        }
        static void Erase()
        {
            Console.Write(" ");
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
            ConsoleColor BGColor = ConsoleColor.Black;
            ConsoleColor FGColor = ConsoleColor.White;


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
                                    Write(character,BGColor,FGColor);
                                }                            
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (fromLeft < Console.WindowWidth - 2)
                            {
                                Console.CursorLeft++;
                                if (Console.CapsLock)
                                {
                                    Write(character, BGColor, FGColor);
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (fromTop < Console.WindowHeight - 2)
                            {
                                Console.CursorTop++;
                                if (Console.CapsLock)
                                {
                                    Write(character, BGColor, FGColor);
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (fromLeft > 1)
                            {
                                Console.CursorLeft--;
                                if (Console.CapsLock)
                                {
                                    Write(character, BGColor, FGColor);
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
                            FGColor = ConsoleColor.Red;
                            break;
                        case ConsoleKey.D2:
                            FGColor = ConsoleColor.Yellow;
                            break;
                        case ConsoleKey.D3:
                            FGColor = ConsoleColor.Green;
                            break;
                        case ConsoleKey.D4:
                            FGColor = ConsoleColor.Blue;
                            break;
                        case ConsoleKey.D5:
                            FGColor = ConsoleColor.Magenta;
                            break;
                        case ConsoleKey.D6:
                            FGColor = ConsoleColor.Cyan;
                            break;
                        case ConsoleKey.D7:
                            FGColor = ConsoleColor.White;
                            break;
                        case ConsoleKey.D8:
                            FGColor = ConsoleColor.Gray;
                            break;
                        case ConsoleKey.D9:
                            FGColor = ConsoleColor.Black;
                            break;
                    }
                }
                if (backgroundColorKeys.Contains(pressedKey))
                {
                    switch (pressedKey)
                    {
                        case ConsoleKey.NumPad1:
                            BGColor = ConsoleColor.Red;
                            break;
                        case ConsoleKey.NumPad2:
                            BGColor = ConsoleColor.Yellow;
                            break;
                        case ConsoleKey.NumPad3:
                            BGColor = ConsoleColor.Green;
                            break;
                        case ConsoleKey.NumPad4:
                            BGColor = ConsoleColor.Blue;
                            break;
                        case ConsoleKey.NumPad5:
                            BGColor = ConsoleColor.Magenta;
                            break;
                        case ConsoleKey.NumPad6:
                            BGColor = ConsoleColor.Cyan;
                            break;
                        case ConsoleKey.NumPad7:
                            BGColor = ConsoleColor.White;
                            break;
                        case ConsoleKey.NumPad8:
                            BGColor = ConsoleColor.Gray;
                            break;
                        case ConsoleKey.NumPad9:
                            BGColor = ConsoleColor.Black;
                            break;
                    }
                }
                if (colorFunctionKeys.Contains(pressedKey))
                {
                    switch (pressedKey)
                    {
                        case ConsoleKey.Add:
                            switch (BGColor)
                            {
                                case ConsoleColor.DarkBlue:
                                    BGColor = ConsoleColor.Blue;
                                    break;
                                case ConsoleColor.DarkGreen:
                                    BGColor = ConsoleColor.Green;
                                    break;
                                case ConsoleColor.DarkCyan:
                                    BGColor = ConsoleColor.Cyan;
                                    break;
                                case ConsoleColor.DarkRed:
                                    BGColor = ConsoleColor.Red;
                                    break;
                                case ConsoleColor.DarkMagenta:
                                    BGColor = ConsoleColor.Magenta;
                                    break;
                                case ConsoleColor.DarkYellow:
                                    BGColor = ConsoleColor.Yellow;
                                    break;
                                case ConsoleColor.Gray:
                                    BGColor = ConsoleColor.White;
                                    break;
                                case ConsoleColor.DarkGray:
                                    BGColor = ConsoleColor.Gray;
                                    break;
                                case ConsoleColor.Black:
                                    BGColor = ConsoleColor.DarkGray;
                                    break;
                            }
                            break;
                        case ConsoleKey.Subtract:
                            switch (BGColor)
                            {
                                case ConsoleColor.Blue:
                                    BGColor = ConsoleColor.DarkBlue;
                                    break;
                                case ConsoleColor.Green:
                                    BGColor = ConsoleColor.DarkGreen;
                                    break;
                                case ConsoleColor.Cyan:
                                    BGColor = ConsoleColor.DarkCyan;
                                    break;
                                case ConsoleColor.Red:
                                    BGColor = ConsoleColor.DarkRed;
                                    break;
                                case ConsoleColor.Magenta:
                                    BGColor = ConsoleColor.DarkMagenta;
                                    break;
                                case ConsoleColor.Yellow:
                                    BGColor = ConsoleColor.DarkYellow;
                                    break;
                                case ConsoleColor.White:
                                    BGColor = ConsoleColor.Gray;
                                    break;
                                case ConsoleColor.Gray:
                                    BGColor = ConsoleColor.DarkGray;
                                    break;
                                case ConsoleColor.DarkGray:
                                    BGColor = ConsoleColor.Black;
                                    break;
                            }
                            break;
                        case ConsoleKey.OemPlus:
                            switch (FGColor)
                            {
                                case ConsoleColor.DarkBlue:
                                    FGColor = ConsoleColor.Blue;
                                    break;
                                case ConsoleColor.DarkGreen:
                                    FGColor = ConsoleColor.Green;
                                    break;
                                case ConsoleColor.DarkCyan:
                                    FGColor = ConsoleColor.Cyan;
                                    break;
                                case ConsoleColor.DarkRed:
                                    FGColor = ConsoleColor.Red;
                                    break;
                                case ConsoleColor.DarkMagenta:
                                    FGColor = ConsoleColor.Magenta;
                                    break;
                                case ConsoleColor.DarkYellow:
                                    FGColor = ConsoleColor.Yellow;
                                    break;
                                case ConsoleColor.Gray:
                                    FGColor = ConsoleColor.White;
                                    break;
                                case ConsoleColor.DarkGray:
                                    FGColor = ConsoleColor.Gray;
                                    break;
                                case ConsoleColor.Black:
                                    FGColor = ConsoleColor.DarkGray;
                                    break;
                            }
                            break;
                        case ConsoleKey.OemMinus:
                            switch (FGColor)
                            {
                                case ConsoleColor.Blue:
                                    FGColor = ConsoleColor.DarkBlue;
                                    break;
                                case ConsoleColor.Green:
                                    FGColor = ConsoleColor.DarkGreen;
                                    break;
                                case ConsoleColor.Cyan:
                                    FGColor = ConsoleColor.DarkCyan;
                                    break;
                                case ConsoleColor.Red:
                                    FGColor = ConsoleColor.DarkRed;
                                    break;
                                case ConsoleColor.Magenta:
                                    FGColor = ConsoleColor.DarkMagenta;
                                    break;
                                case ConsoleColor.Yellow:
                                    FGColor = ConsoleColor.DarkYellow;
                                    break;
                                case ConsoleColor.White:
                                    FGColor = ConsoleColor.Gray;
                                    break;
                                case ConsoleColor.Gray:
                                    FGColor = ConsoleColor.DarkGray;
                                    break;
                                case ConsoleColor.DarkGray:
                                    FGColor = ConsoleColor.Black;
                                    break;
                            }
                            break;
                    }

                }
                if (ConsoleKey.Spacebar == pressedKey)
                {
                    Write(character, BGColor, FGColor);
                }
                if (ConsoleKey.Backspace == pressedKey)
                {
                    Erase();
                }
                if (ConsoleKey.Escape == pressedKey)
                {
                    OpenMenu();
                }
            }
        }
    }
}
