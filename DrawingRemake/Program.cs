using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DrawingRemake
{
    public class Menu
    {
        private string MenuState = "Closed";
        public string[] Options;
        public int currentSelected = 0;

        public void Open()
        {
            int WidestString = 0;
            int[] StartCorner = [0, 0];
            int Offset = 1;
            bool ScrollHints = false;

            for (int i = 0; i < Options.Length; i++)
            {
                WidestString = WidestString < Options[i].Length ? Options[i].Length : WidestString;
            }
            Offset = Options.Length > 5 ? 9 : (Options.Length * 2) - 1;
            StartCorner = [(Console.WindowWidth / 2) - ((WidestString + 4) / 2), (Console.WindowHeight / 2) - Offset];

            for (int i = 0; i < Options.Length; i++)
            {
                Console.SetCursorPosition(StartCorner[0], StartCorner[1] + (i * 4));

                Console.Write('┌');
                for (int i2 = 0; i2 < WidestString + 2; i2++)
                {
                    Console.Write("─");
                }
                Console.Write('┐');

                Console.SetCursorPosition(StartCorner[0], StartCorner[1] + 1 + (i * 4));

                Console.Write('│');
                for (int i2 = 0; i2 < ((WidestString + 2) - Options[i].Length) / 2; i2++)
                {
                    Console.Write(' ');
                }
                Console.Write(Options[i]);
                for (int i2 = 0; i2 < (Options[i].Length % 2 == 0 ? (WidestString + 2 - Options[i].Length) / 2 : (WidestString + 2 - Options[i].Length) / 2 + 1); i2++) // Itt nem lesz jo valami
                {
                    Console.Write(' ');
                }
                Console.Write('│');

                Console.SetCursorPosition(StartCorner[0], StartCorner[1] + 2 + (i * 4)); // vagy itt

                Console.Write('└');
                for (int i2 = 0; i2 < WidestString + 2; i2++)
                {
                    Console.Write("─");
                }
                Console.Write('┘');
           }

            MenuState = "Open";
        }
        public void Close()
        {
            MenuState = "Closed";
        }
        public string GetStatus()
        {
            return MenuState;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Window Settings
            Console.Title = "Drawing";
            Console.WindowHeight = Console.LargestWindowHeight / 2;
            Console.WindowWidth = Console.LargestWindowWidth / 2;
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);

            // Window Settings END

            Menu MainMenu = new Menu();

            MainMenu.Options = ["acas", "asasasasasa", "aebs", "awzrcs"];
            

            while (true)
            {
                string input =  Console.ReadLine();
                switch (input)
                {
                    case "close":
                        MainMenu.Close();
                        break;
                    case "open":
                        MainMenu.Open();
                        break;
                    case "status":
                        Console.WriteLine(MainMenu.GetStatus());
                        break;
                }
            }
            
        }
    }
}
