namespace ProgramozasiTetelek
{
    internal class Program
    {
        public static int Sorozatszamitas(int[] tomb, int tombLength) 
        { 
            int ertek = 0;
            int i = 0;
            while (i < tombLength) 
            {
                ertek = ertek + tomb[i];
                i++;
            }
            return ertek;
        }
        public static bool Eldontes(int[] tomb, int tombLength)
        {
            int i = 0;
            while (i <= tombLength && !(tomb[i] % 2 == 0))
            {
                i++;
            }
            return i <= tombLength;
        }
        public static bool EldontesMinden(int[] tomb, int tombLength)
        {
            int i = 0;
            while (i <= tombLength && tomb[i] % 2 == 0)
            {
                i++;
            }
            return i > tombLength;
        }
        public static bool RendezettE(int[] tomb, int tombLength)
        {
            int i = 0;
            while (i <= tombLength && tomb[i] % 2 == 0)
            {
                i++;
            }
            return i > tombLength;
        }
        static void Main(string[] args)
        {
            int[] tomb = {1, 2, 54, 56, 46, 2, 21, 14, 7};

            Console.WriteLine(EldontesMinden(tomb, tomb.Length));
            
        }
    }
}
