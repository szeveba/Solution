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
        public static void F5()
        {
            decimal num1 = ReadDecimal("Adj meg egy számot: ");
            decimal num2 = ReadDecimal("Adj meg még egy számot: ");
            if (num1 == num2)
            {
                Console.WriteLine("A két szám egyenlő.");
            }
            else
            {
                Console.WriteLine($"A nagyobbik szám: {(num1 < num2 ? num2 : num1)}");
            }
        }
        private static decimal ReadDecimal(string message)
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
        private static int ReadInt(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            int num = 0;

            while (!int.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}