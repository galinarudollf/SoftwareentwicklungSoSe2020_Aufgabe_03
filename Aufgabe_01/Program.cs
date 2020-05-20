using System;

namespace Aufgabe_01
{
    class Program
    {
        private static readonly int langePause = 1000;
        private static readonly int kurzePause = 300;
        private static readonly int punkt = 100;
        private static readonly int strich = 300;

        static void Flash(int ms)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            System.Threading.Thread.Sleep(ms);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

        }
        static void Main(string[] args)
        {
            String umzuwandeln = "Zeichenkette";
            Console.WriteLine(umzuwandeln);
            foreach (char zeichen in umzuwandeln)
            {
            }
        }
    }
}
