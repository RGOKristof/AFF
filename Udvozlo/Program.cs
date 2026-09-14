namespace Udvozlo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Hogy hivnak?");
            Console.Write("Nev: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello {userName}!");
        }
    }
}
