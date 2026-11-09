using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DrawingRemake
{
    internal class Program
    {
        public class Menu
        {
            private string MenuState = "Closed";
            public string[] Options;

            public void Open()
            {
                int WidestString = 0;
                int[] StartCorner = [0,0];
                int Offset = 1;
                bool ScrollHints = false;

                for (int i = 0; i < Options.Length; i++)
                {
                    WidestString = WidestString < Options[i].Length ? Options[i].Length : WidestString ;
                }
                Offset = Options.Length > 5 ? 9 : (Options.Length * 2) - 1;
                StartCorner = [(Console.WindowWidth / 2) - ((WidestString + 3) / 2), (Console.WindowHeight / 2) - Offset];

                for (int i = 0; i < Options.Length; i++)
                {
                    
                }

                Console.Write("┌");
                for (int i = 0; i < WidestString+2; i++)
                {
                    Console.Write("─");
                }
                Console.Write("┐");


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
        static void Main(string[] args)
        {
            // Window Settings
            Console.Title = "Drawing";
            Console.WindowHeight = Console.LargestWindowHeight / 2;
            Console.WindowWidth = Console.LargestWindowWidth / 2;
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);
            
            Menu MainMenu = new Menu();

            MainMenu.Options = ["a", "a", "a", "a", ];
            

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
