namespace GY1
{
    public static class Suranyisz
    {
        /// <summary>
        /// Írj programot, ami kiírja a képernyőre, hogy ”Hello world!”!
        /// </summary>
        public static void F1()
        {
            Console.WriteLine("Hello world!");
        }
        /// <summary>
        /// Írj programot, beolvassa a felhasználó nevét, majd köszön neki!
        /// </summary>
        public static void F2()
        {
            Console.Write("Hogy hívnak: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Szia {name}!"); //Console.WriteLine("Szia "+name);
        }
        /// <summary>
        ///  Írj programot, ami beolvas egy számot, majd kiírja a kétszeresét!
        /// </summary>


        /// <summary>
        /// Írj programot, ami beolvas egy számot, majd kiírja a kétszeresét!
        /// </summary>
        public static void F3()
        {
            decimal num = ReadDecimal("Adj meg egy számot: ");
            if (num < decimal.MaxValue / 2) Console.WriteLine($"Az általad megadott szám kétszerese: {num * 2}");
            else Console.WriteLine("Ilyen nagy számot nem tudok beszorozni kettővel.");
        }
        /// <summary>
        /// Írj programot, ami beolvas két számot, majd kiírja:
        /// a.az összegüket;
        /// b.különbségüket;
        /// c.szorzatukat;
        /// d.hányadosukat, ha lehet!
        /// </summary>
        public static void F4()
        {
            decimal num1 = ReadDecimal("Adj meg egy számot: ");
            decimal num2 = ReadDecimal("Adj meg még egy számot: ");
            Console.WriteLine($"\t+ => {num1 + num2}");
            Console.WriteLine($"\t- => {num1 - num2}");
            Console.WriteLine($"\t* => {num1 * num2}");
            Console.WriteLine($"\t/ => {num1 / num2}");
        }

        /// <summary>
        /// Írj programot, mely beolvas két egész számot, és kiírja a képernyőre a nagyobbikat!
        /// </summary>
        public static void F5()
        {
            long num1 = ReadLong("Adj meg egy számot: ");
            long num2 = ReadLong("Adj meg még egy számot: ");
            if (num1 == num2)
            {
                Console.WriteLine("A két szám egyenlő.");
            }
            else
            {
                Console.WriteLine($"A nagyobbik szám: {(num1 < num2 ? num2 : num1)}");
            }
        }
        private static decimal ReadDecimal(string message = "Adj meg egy számot: ")
        {
            Console.Write(message);
            string input = Console.ReadLine();
            decimal num = 0;

            while (!decimal.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }

        private static long ReadLong(string message = "Adj meg egy számot: ")
        {
            Console.Write(message);
            string input = Console.ReadLine();
            long num = 0;

            while (!long.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }
        private static double ReadDouble(string message = "Adj meg egy számot: ")
        {
            Console.Write(message);
            string input = Console.ReadLine();
            double num = 0;

            while (!double.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }

        /// <summary>
        ///  Írj programot, mely beolvas két pozitív egész számot, és kiírja a számtani és mértani közepüket! A gyökvonáshoz használd a Math.Sqrt() függvényt!
        /// </summary>
        public static void F8()
        {
            long num1 = ReadLong();
            long num2 = ReadLong("Adj meg mégegy számot: ");
            Console.WriteLine($"Számtani közép: {(num1 + num2) / 2.0}");
            Console.WriteLine($"Mértani közép: {Math.Round(Math.Sqrt(num1 * num2), 3)}");
        }
        /// <summary>
        /// Írj programot, mely beolvas egy pozitív egész számot, és kiírja az egész számokat a képernyőre eddig a számig, egymástól szóközzel elválasztva!
        /// </summary>
        public static void F15()
        {
            long num1 = ReadLong();
            for (int i = 1; i < num1; i++)
            {
                Console.Write(i + " ");
            }
        }
        /// <summary>
        /// Írj programot, mely beolvas egy pozitív egész számot, és kiírja az osztóit!
        /// </summary>
        public static void F17()
        {
            long num1 = ReadLong();
            Console.Write("Az általad megadott szám osztói: [1");
            for (int i = 2; i < num1; i++)
            {
                if (num1 % i == 0)
                {
                    Console.Write(", " + i);
                }
            }
            Console.Write(", " + num1 + "]");
        }
        /// <summary>
        /// Írj programot, mely beolvassa a hatvány alapját és a kitevőt, és kiírja a hatványértéket!
        /// </summary>
        public static void F20()
        {
            double num1 = ReadDouble("Adj meg egy hatványalapot: ");
            double num2 = ReadDouble("Adj meg egy kitevőt: ");
            Console.WriteLine("A hatványérték: " + Math.Pow(num1, num2));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Suranyisz.F20();
        }
    }
}