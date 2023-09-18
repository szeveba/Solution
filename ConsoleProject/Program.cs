namespace ConsoleProject
{
    internal class Program
    {
        static void Teszt(int[] a)
        {
            a[0] = 0;
        }
        static int Osszeadas(ref int a, ref int b)
        {
            a += b; // a = a + b;
            return a;
        }
        static void Main(string[] args)
        {
            int asd = 13;
            int eredmeny = Osszeadas(ref asd, ref asd);
            Console.WriteLine(eredmeny);
            Console.WriteLine(asd);
            //deklarálás
            int a;
            //értékadás
            a = 3;
            //inicializálás
            //típus változónév = literál
            int b = 4;
            //vagy
            ////típus változónév = kifejezés
            int b2 = a + a;


            //Típusok 
            //egész számok
            short a1; //Int16
            int a2; //Int32
            long a3; //Int64

            //Nem egész szám
            double d1;
            float d2;
            decimal d3;
            //nem egész szám inicializálása
            double d5 = 3.14;

            //karakterlánc inicializálása literállal
            string s = "hello";
            //karakter inicializálása literállal
            char c = 'c';

            //logikai változó inicializálása literállal
            bool b3 = true;
            

            //Tömbök
            var t = new int[3];
            char[] t2 = new char[6];
            int[] t3 = { 1, 2, 3, 4 };
            int[] t4 = Enumerable.Range(1, 4).ToArray();
            Console.Clear();
            Console.WriteLine(t3[0]);
            Teszt(t3);
            Console.WriteLine(t3[0]);

            //Konzolos alapok
            //Konzolra írás
            Console.Write("123");
            //Konzolra kiírás, a végén sortörtés (cw + tab + tab)
            Console.WriteLine("123");
            Console.WriteLine("Ez már új sorba fog kerülni!");
            //Konzolról egy sor beolvasása és tárolása
            string visszateresiErtek = Console.ReadLine();

            //string átalakítása int-re
            string ertek = "3";
            int intErtek = int.Parse(ertek);
            //string átalakítása double-re
            ertek = "3,14"; 
            // !!!!!!!!!!!!!
            // a magyarok vesszővel írják, ezt számításba veszi a C#
            // ha ponttal adod meg => InvalidFormatException
            double doubleErtek = double.Parse(ertek);

            //Konzolról szám beolvasása, átalakítása, kétszeresének kiíratása konzolra
            string input = Console.ReadLine();
            double szamertek = double.Parse(input);
            double output = szamertek * 2;
            Console.WriteLine(output);
            Console.WriteLine(double.Parse(Console.ReadLine())*2);
        }
    }
}