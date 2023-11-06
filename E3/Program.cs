using System.Collections.Generic;
using System.Diagnostics;

namespace E3
{
    internal class Program
    {
        static void F1()
        {
            int.Parse("123");
        }
        static void Main(string[] args)
        {
            /*
             * 
                3.7.1.6.6 Vezérlési szerkezetek, ciklusok
                Logikai (boolean) kifejezések
                - Boolean változók értelmezése, inicializálása, deklarálása
                - Aritmetikai alapfogalmak, boolean változók összehasonlítása, operátorok
                - Két- és többirányú (if-then-else) elágazás
                - Döntési változók, vezérlési struktúrák elméleti bevezető
                - Feltételeken alapuló futtatás
                - If-then-else elágazások
            */
            bool l = false; //true;


            string s = "asdasdasd";
            l = !l;
            l = true && true; // true
            l = true || false; // true
            l = s.Length != 0; //s.Length != 0 => string nem üres
            // < <= > >= ! == != (is) && ||
            bool f;
            f = false;
            bool f2 = false;

            if (true)
            {

            }
            else
            {
                if (l)
                {

                }
            }



            /*
                Összetett kifejezések, magas szintű operátorok:
                - Hármas operátor (? : )
                - Érték szerinti (Switch) elágazás
                - Switchelmélet
                - Szintaxis
                - Összehasonlítás If-fel

            operátorok operandusok száma szerint csoportosítva (nem teljes lista)
            1. operandusos
            !bool ++i --i 

            2. operandusos
            T+T * + - / % ||  += *= &= |= stb...
            3. operandusos
            Conditional (ternary) operator [ ? : ]
            */
            int szam = new Random().Next(-100, 100);

            //ternary operátorral
            string párosE = (szam % 2 == 0) ? "Páros" : "Páratlan";

            //ugyan az if-el
            if (szam % 2 != 0)
            {
                párosE = "Páratlan";
            }
            else
            {
                párosE = "Páros";
            }



            string ss = ""; // Console.ReadLine();
            if (ss == "asd" || ss == "WASD")
            {
                Console.WriteLine("1");
            }
            else if (ss == "")
            {
                Console.WriteLine("2");
            }
            else
            {
                Console.WriteLine("3");
            }

            switch (ss)
            {
                case "asd":
                case "WASD":
                    Console.WriteLine("1");
                    break;
                case "":
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("3");
                    break;
            }
    

            /*
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
            bool logikaiKifejezés = false;

            //ELŐLTESZTELŐ
            while (logikaiKifejezés)
            {
                //continue // adott ciklusmag további lépésinek átugrása, következő körhöz ugrás
                //break; // adott ciklus futásának megszakítása

            }
            //SZÁMLÁLÓ
            //for -> tab tab
            for (int i2 = 0; i2 < 10; i2++)
            {

                //... ciklusmag utasításai
            }
            
            int i = 0;
            while (i < 10)
            {
                //... ciklusmag utasításai
               i++;
            }
            //gyűjtemények bejárásához
            //!!!!!!!!!!!!!!! NE VÁLTOZTASD MEG A GYŰJTEMÉNY ELEMSZÁMÁT BEJÁRÁS KÖZBEN PL TÖRLÉS - HOZZÁADÁS
            var t = new int[3];

            foreach (var item in t)
            {
                //.... ciklusmag
            }

            var enumerator = t.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = (int)enumerator.Current;
                //.... ciklusmag
                enumerator.MoveNext();
            }


            int a = 2, b = 3;

            //HÁTULTESZTELŐ
            Math.Min(a, b);
            char c = ' ';
            do
            {
                c = char.ToLower(Console.ReadKey().KeyChar);
                switch (c)
                {
                    case '1':
                    case '2':
                        break;
                    case 'q':
                        Console.WriteLine("KILÉPÉS...");
                        break;
                    default:
                        Console.WriteLine("NINCS ILYEN OPCIÓ!");
                        break;
                }
            } while (c != 'q');


            Console.WriteLine("Hello, World!");
        }
    }
}