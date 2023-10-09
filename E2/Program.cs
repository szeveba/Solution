using System;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace E2
{
    /*
     * 
     * 
3.7.1.6.4 Metódusok
    - Függvénydefiníciók
    - Kód strukturálása osztályszinten
    - Függvények haszna és célja
    - Osztályváltozók elérése
    - Scope
    - Argumentumok, visszatérési érték

3.7.1.6.5 Beépített segédosztályok
- String osztály
- Nyelvi beépített osztályok használatának alapja, dokumentációértelmezés
- String osztály legfontosabb függvényei és használatuk: indexOf, charAt, substring() 
- A Stringkonkatenálás és az immutable fogalma
- Stringek összehasonlítása
- A Random osztály
- Véletlenszám-generálás felhasználása a programozásban, pszeudo-véletlen elméleti 
kitekintő
- Véletlenszám generálása a Random osztály segítségével, next...() függvények
- A Math osztály
- Math osztály felhasználásának lehetőségei
- Statikus metódusok szerepe
- Legfontosabb függvények: max(), min(), sqrt()

3.7.1.6.6 Vezérlési szerkezetek, ciklusok
Logikai (boolean) kifejezések
- Boolean változók értelmezése, inicializálása, deklarálása
- Aritmetikai alapfogalmak, boolean változók összehasonlítása, operátorok
- Két- és többirányú (if-then-else) elágazás
- Döntési változók, vezérlési struktúrák elméleti bevezető
- Feltételeken alapuló futtatás
- If-then-else elágazások
Összetett kifejezések, magas szintű operátorok:
- Hármas operátor (? : )
- Érték szerinti (Switch) elágazás
- Switchelmélet
- Szintaxis
- Összehasonlítás If-fel
Ciklusok:
- “for” ciklus
- Ciklusok jelentősége elméleti bevezető
- A for ciklust ismertető elmélet
- For ciklus szintaxis
- Ciklus scope 
- Ciklusok debugolása
- Végtelen ciklus
- “do-while” ciklusok
- Elöltesztelő ciklus
- Hátultesztelő ciklus
- Ciklustípusok összehasonlítása, mikor melyiket érdemes használni
Ciklusvezérlés:
- Ciklus futtatásának leállítása, Break
- Ciklusátugrás, Continue
     */
    internal class Program
    {
        public static bool Eldöntés(string[] tömb)
        {
            int i = 0;
            while (i<tömb.Length && !(tömb[i]!=""))
            {
                i += 1;
            }
            bool van = i < tömb.Length;
            return van;
        }
        public static bool Eldöntés2(string[] tömb)
        {
            for (int i = 0; i < tömb.Length; i++)
            {
                if (tömb[i] == "") return false;
            }
            return true;
        }
        static void Feladat1()
        {
            Console.WriteLine("Hello world!");
        }
        static void Feladat2()
        {
            Console.Write("Adj meg egy nevet: ");
            string nev = Console.ReadLine();
            Console.WriteLine($"Szia {nev}!");
        }

        static int EgészSzámBekérés(string üzenet)
        {
            Console.Write(üzenet+": ");
            string inp = Console.ReadLine();
            int op = int.Parse(inp);
            return op;
        }


        static void OsztályszintűEljárás()
        {

        }
        static bool OsztályszintűFüggvény()
        {
            return true;
        }
        void PéldányszintűEljárás()
        {

        }

        public static Random Random = new Random();
        static void Main(string[] args)
        {
            Feladat1();
            int x = 1, y = 2;

            if (args.Length == 0)
            {
                Console.WriteLine("args üres");
            }
            else
            {
                Console.WriteLine("args nem üres");
            }

            if (x < y)
            {
                Console.WriteLine("x kisebb mint y");
                
            }
            else
            {
                if (x > y)
                {
                    Console.WriteLine("x nagyobb mint y");
                }
                else
                {
                    Console.WriteLine("x egyenlő y");
                }
            }


            //számláló
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine();
            }
            //előltesztelő ciklus
            while (true)
            {

            }
            //hátultesztelő ciklus
            do
            {

            } while (true);
            
            //bejárás
            int[] gyűjtemény = new int[] { 1, 2, 3 };
            foreach (var item in gyűjtemény)
            {

            }

            //Program p = new Program();
            //p.PéldányszintűEljárás();
            OsztályszintűEljárás();
            OsztályszintűFüggvény();


            //Console.ReadLine();
            // ELJÁRÁS VS FÜGGVÉNY ? METÓDUS
            Console.WriteLine("Hello, World!");
            // LÁTHATÓSÁG -> private, protected, internal, public

            Osztály osztály = new Osztály();

            Diák d1 = new Diák();
            d1.Név = "Jani";
            d1.SzületésDátum = DateTime.Now.AddYears(-18);
            Diák d2 = new Diák();
            d2.Név = "Géza";
            d2.SzületésDátum = DateTime.Now.AddYears(-15);


            //Példányosítás
            Asd példány = new Asd();

            Console.WriteLine("ASDASD");
            Console.WriteLine("ASDASD");
            Console.WriteLine("ASDASD");
            Console.WriteLine("ASDASD");
            Console.WriteLine("ASDASD");
            Console.WriteLine("ASDASD");


            példány.ParaméterNélküliEljárás();
            string s = "asd";
            példány.EgyParaméteresEljárás(s);
            példány.EgyParaméteresEljárás("literál");
            példány.TöbbParaméteresEljárás("SZIA", ConsoleColor.Green);
            //Metódus név túlterhelés -> ugyan azon a néven több metódust is definiálunk (paraméter lista különböző)
            példány.TöbbParaméteresEljárásOpcionálisParaméterekkel("szia");
            példány.TöbbParaméteresEljárásOpcionálisParaméterekkel("szia", ConsoleColor.Green);
            példány.TöbbParaméteresEljárásOpcionálisParaméterekkel("szia", ConsoleColor.Green, ConsoleColor.DarkRed);
            példány.Üdvözlés("Jani");
            példány.Üdvözlés("Jani", "Üdv");
            int összeg = példány.Összead(1, 2);

            //3.7.1.6.5 Beépített segédosztályok
            //-String osztály
            string karakterlánc = "karakterlánc";
            //-String osztály legfontosabb függvényei és használatuk: indexOf, charAt, substring()
            int rKarakterElsőElőfordulásánakIndexe = karakterlánc.IndexOf('r');
            //'charAt' -> karakter a paraméterként átadott index helyén
            char karakterA3masIndexHelyén = karakterlánc[3]; //'a'
            //- Stringek összehasonlítása
            if (karakterlánc == "asd")
            {
                Console.WriteLine("A string értéke asd");
            }
            else
            {
                Console.WriteLine("A string értéke " + karakterlánc);
            }
            //- A Random osztály
            Random rnd = new Random();
            int véletlenszerűNemNegatívEgészSzám = rnd.Next();
            int száználKisebbVéletlenszerűNemNegatívEgészSzám = rnd.Next(100);
            int mínuszHáromVagyNagyobbDeSzáználKisebbVéletlenszerűEgészSzám = rnd.Next(-3, 100);
            double nullaVagyAnnálNagyobbDeEgynélKisebbNemEgészSzám = rnd.NextDouble();
            //- A Math osztály
            int a = 1;
            int b = 2;
            int c = Math.Min(a, b); // a értéke kisebb => c = a = 1
            c = Math.Max(a, b); // b értéke nagyobb => c = b = 2
            double d = Math.Sqrt(c); //d = c gyöke
            d = Math.Pow(c, 3); //d = c^3
            //köbgyök
            d = Math.Cbrt(c);
        }
    }

    class Osztály
    {
        public Osztály()
        {
            Diákok = new List<Diák>();
        }
        public List<Diák> Diákok { get; }
        public string Megnevezés { get; set; }
    }
    class Diák : Ember
    {
        public static void Üdvözöl()
        {
            Console.WriteLine("Jónapot kívánok!");
        }
        public void Bemutatkozás()
        {
            Console.WriteLine("Üdvözlöm, a nevem " + Név);
        }
        public Osztály Osztály { get; set; }
        public static List<string> SzlengSzavak { get; set; }
    }
    class Tanár : Ember
    {

    }
    class Osztályfőnök : Tanár
    {

    }
    class Ember
    {
        public string Név { get; set; }
        public DateTime? SzületésDátum { get; set; }
    }

    class Asd
    {
        public Asd()
        {
            //KONSTRUKTOR -> OOP-ban szerepe: létrehozza az objektumomat, memória referenciával tér vissza
        }
        public void ParaméterNélküliEljárás()
        {
            Console.WriteLine("Ez egy eljárás");
        }
        public void EgyParaméteresEljárás(string paraméter)
        {
            Console.WriteLine(paraméter);
        }
        public void TöbbParaméteresEljárás(string üzenet, ConsoleColor szín)
        {
            Console.ForegroundColor = szín;
            Console.WriteLine(üzenet);
            Console.ResetColor();
        }
        public void TöbbParaméteresEljárás(string üzenet, ConsoleColor betűSzín, ConsoleColor háttérszín)
        {
            Console.ForegroundColor = betűSzín;
            Console.BackgroundColor = háttérszín;
            Console.WriteLine(üzenet);
            Console.ResetColor();
        }
        public void TöbbParaméteresEljárásOpcionálisParaméterekkel(string üzenet, ConsoleColor? betűSzín = null, ConsoleColor? háttérszín = null)
        {
            if (betűSzín != null)
            {
                Console.ForegroundColor = betűSzín.Value;
            }
            if (háttérszín != null)
            {
                Console.BackgroundColor = háttérszín.Value;
            }
            Console.WriteLine(üzenet);
            Console.ResetColor();
        }
        public static void StatikusTöbbParaméteresEljárásOpcionálisParaméterekkel(string üzenet, ConsoleColor? betűSzín = null, ConsoleColor? háttérszín = null)
        {
            if (betűSzín != null)
            {
                Console.ForegroundColor = betűSzín.Value;
            }
            if (háttérszín != null)
            {
                Console.BackgroundColor = háttérszín.Value;
            }
            Console.WriteLine(üzenet);
            Console.ResetColor();
        }
        //void TöbbParaméteresEljárás(string, ConsoleColor, ConsoleColor )
        //public void TöbbParaméteresEljárás(string üzenet, ConsoleColor betűSzín, ConsoleColor háttérszín)
        //public void TöbbParaméteresEljárás(string üzenet, ConsoleColor betűSzín, ConsoleColor asd)

        public void Üdvözlés(string név, string megszólítás = "Szia")
        {
            Console.WriteLine(megszólítás + " " + név + "!");
        }
        public int Összead(int a, int b)
        {
            int op = a + b;
            return op;
        }
        public bool PozitívEgészSzámE0(double d)
        {
            if (d > 0)
            {
                if (d == (int)d)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool PozitívEgészSzámE1(double d)
        {
            if (d > 0)
            {
                if (d == (int)d)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PozitívEgészSzámE2(double d)
        {
            return d > 0 && d == (int)d;
        }
        public bool PozitívEgészSzámE3(double d)
        {
            if (d <= 0) return false;
            if (d != (int)d) return false;
            return true;
        }
    }

}