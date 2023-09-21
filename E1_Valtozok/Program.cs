namespace E1_Valtozok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Primitív típusok

            bool logikai = false; //true
            byte b1 = 255;
            short kisebb = 0;
            int egész = 0;
            long nagyobb = 0;
            float kisebbd = 0;
            double nemegész = 0.5;
            decimal nagyobbd = 0;

            //aritmetikai műveletek
            // + - * / %
            // += -= *= /= %= | a = a + b; <-> a += b;
            // int int -> int 
            // 5 / 2 -> 2
            // double int -> double
            // 5.0 / 2 -> 2.5
            // (int)2.5 -> 2
            // (double)5 / 2 -> 2.5
            egész = egész * 2;

            int e1 = 5;
            int e2 = 2;
            double ee1 = e1 / e2;
            double ee2 = (double)e1 / e2;

            double e3 = (1 + 10) / 2;

            //'Szöveges' típus
            //string -> karakterlánc
            string s = "asd \"asd\" ad d";
            //char -> karakter
            char c = '\'';
            // első karakter: s[0]
            // utolsó karaktert: s[s.Length - 1]

            // Stringkezelési alapok
            //logikai értékkel visszatérő metódusok
            bool vanEbenne = s.Contains('s');
            s.Contains("asd");
            s.EndsWith("asd");
            s.StartsWith("asd");


            //darabolás
            s.Split(); //szóközök mentén
            s.Split('a'); //karakter mentén
            s.Split(new char[] { 'a', 'A' }); //karakterek mentén
            s.Split("asd"); //karakterlánc mentén
            s.Split("asd", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("asdasdasd".Split("asd").Length);
            Console.WriteLine("asdasdasd".Split("asd", StringSplitOptions.RemoveEmptyEntries).Length);

            //átalakító metódusok
            s.ToUpper();
            s.ToLower();

            //szóköz eltávolítás
            s.Trim(); s.TrimStart(); s.TrimEnd();
            s.Replace('.', ','); //karakterek lecserélése
            s.Replace("asd", ""); //karakterlánc összes előfordulásának 'törlése'
            s.Remove(1, 1); //csak az első karakter
            s.Substring(1); //minden az első karakteren kívül, 1es indextől
            s.Substring(1, 1); //csak a második karakter
            s.IndexOf('c'); // c első előfordulásának indexe
            s.IndexOf("asd");
            s.LastIndexOf("asd");

            // String konkatenáció
            // stringen + értelmezve van -> összefűzés
            string s1 = "a";
            string s2 = "b";
            string s3 = s1 + s2 + s2 + s2;
            s3 += "asd";

            //String interpolation (gyorsabb)
            // "a + b"
            s3 = $"{s1} + {s2}"; //s3 = s1 + " + " + s2;

            /*
            StringBuilder sb = new StringBuilder();
            sb.Append(s3);
            sb.AppendLine();
            sb.ToString();
            */

            /*
            Stopwatch w = new Stopwatch();
            w.Start();
            w.Start();
            int eltelt = w.ElapsedMilliseconds;
            */

            //Escape karakter -> \
            /*
             *\t -> tabulátor
             *\n -> új sor beszúrása
             */
            s = "\"";
            s = $"\" {{ }}";
            s = "\\";
            s = "D:\\publish\\Application Files\\AlkuSandbox_1_0_0_0";
            s = @"D:\publish\Application Files\AlkuSandbox_1_0_0_0";

            int[] t = new int[3];
            Console.WriteLine(t);

            //Konzolra írás
            Console.BackgroundColor = ConsoleColor.DarkBlue; //karakter mögötti szín beállítása
            Console.ForegroundColor = ConsoleColor.Magenta; //karakter színe
            Console.Write("asd"); //konzolra írás
            Console.WriteLine(s); //konzolra írás majd új sor
            Console.ResetColor();
            Console.Clear();
            object b;

            b = Console.WindowHeight; //hány sorból áll a konzol a képernyőn
            b = Console.WindowWidth;  //hány oszlopból áll a konzol a képernyőn
            b = Console.CursorLeft;   //balról hány karakterre van a kurzor aktuálisan
            b = Console.CursorTop;    //fentről hány karakterre van a kurzor aktuálisan
            Console.SetCursorPosition(0, 0);

            //Konzolról olvasás
            //b = Console.ReadLine();
            //ConsoleKeyInfo read = Console.ReadKey(); //karakter leütéséig blokkol, visszatér a leütött karakterrel

            //offtopic: mi a var?
            IEnumerable<IGrouping<char, char>> q = "asdasdasda".OrderBy(x => x).GroupBy(x => x);
            var ígySokkalJobb = "asdasdasda".OrderBy(x => x).GroupBy(x => x);


            // típuskonverzió
            string szamS = "3,14";
            double szamD = double.Parse(szamS);
            int szamI = int.Parse("3");

            //Fájlbeolvasási alapok
            File.WriteAllLines("asd.txt", Enumerable.Range(0, 100).Select(x => x.ToString()));
            string[] bemenet = File.ReadAllLines("asd.txt");
            File.AppendAllLines("asd.txt", new string[] { "egy", "kettő" });

            //Logikai operátorok
            /*
             * és &&
             * vagy ||
             * tagadás !
             * egyenlőségvizsgálat ==
             * !=
             * < > <= >=
             */
            if (bemenet.Length > 0)
            {

            }
            else
            {

            }

            if (bemenet.Length > 0) Console.WriteLine("0 sor van a fájlban");
            else Console.WriteLine("tövv sor van a fájlban");

            char karakter = Console.ReadKey().KeyChar;
            if (karakter == '1')
            {
                Console.WriteLine(1);
            }
            else if (karakter == '2')
            {
                Console.WriteLine(2);
            }
            else if (karakter == '3')
            {
                Console.WriteLine(3);
            }
            else
            {
                Console.WriteLine('?');
            }

            switch (karakter)
            {
                case '1':
                    Console.WriteLine(1);
                    break;
                case '2':
                    Console.WriteLine(2);
                    break;
                case '3':
                    Console.WriteLine(3);
                    break;
                default:
                    Console.WriteLine('?');
                    break;
            }

            //++ inkrementálás -> értéknövelés egyel a++ == a+=1
            //-- dekrementálás -> értékcsökkentés egyel (a--) == (a-=1) == (a = a - 1)
            // i++ != ++i

            while (true)
            {
                break;
            }

            int idx = 0;
            while (idx < 100)
            {
                Console.WriteLine(idx);
                idx = idx + 1; // ++idx; idx++; idx += 1;
            }

            for (int i = 100; i != 0; i -= 2)
            {
                Console.WriteLine(i);
            }

            foreach (var item in Enumerable.Range(0, 100))
            {
                Console.WriteLine(item);
            }

            do
            {
                break; //continue;
            } while (true);
        }
    }
}