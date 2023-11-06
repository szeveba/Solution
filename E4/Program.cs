using System.Net;

namespace E4
{
    internal class Program
    {
        /*
         * 
                3.7.1.6.7 Tömbök és listák
                - Mátrixok kezelése
                - Listák bevezetése
                - ArrayList / List definiálása, inicializálása
                - ArrayList / List elemének módosítása
                - ArrayList / List bejárása iterátor- és ciklusok segítségével
                - Autoboxing
        */

        static T TömbElsőEleme<T>(T[] tömb)
        {
            return tömb[0];
        }
        static T? TömbUtolsóEleme<T>(T[] tömb)
        {
            if (tömb.Length == 0) return default;
            return tömb[tömb.Length - 1];
            /* Ekvivalens megoldások
            return tömb.Length == 0 ? default : tömb[tömb.Length - 1];

            if (tömb.Length != 0)
            {
                return tömb[tömb.Length - 1];
            }
            else
            {
                return default;
            }
            */
        }

        static void Main(string[] args)
        {
            //indexelés a C#-ban 0-tól indul
            char[] chars1 = { 'A', 'B', 'C' };
            char[] chars2 = new char[3];
            chars2[0] = 'A';
            chars2[1] = 'B';
            chars2[2] = 'c';
            chars2[2] = 'C';
            //chars1 != chars2 => a referencia nem egyezik

            // Tömb méretének lekérdezése
            int tömbElemszáma = chars2.Length;

            // Tömbök bejárása

            for (int i = 0; i < chars2.Length; i++)
            {
                //... ciklusmag
            }

            foreach (var item in chars2)
            {
                //... ciklusmag
            }

            // IndexOutOfRangeException amikor rosszul indexelsz

            // Többdimenziós tömbök
            // 2D
            /*
             * 1 2 3
             * 4 5 6
             * 7 8 9
             * 
             * INDEXELÉS
             * 00 01 02
             * 10 11 12
             * 20 21 22
             */
            int[,] t2d = new int[3, 3];
            t2d[0, 0] = 1;
            t2d[0, 1] = 2;
            t2d[0, 2] = 3;
            t2d[1, 0] = 4;
            t2d[1, 1] = 5;
            t2d[1, 2] = 6;
            t2d[2, 0] = 7;
            t2d[2, 1] = 8;
            t2d[2, 2] = 9;

            //4D
            int[,,,] t4d = new int[3, 3, 3, 3];

            // Vektor? Mátrix?
            // Vektor -> egy dimenziós tömb
            // Mátrix -> több dimenziós tömb

            //JAGGED ARRAY (tanmenetben nem szereplő ismeret)

            /* --->
             * 1 2
             * 3
             * 4 5 6 7
             * 8 9
             */
            int[][] tj = new int[4][];
            tj[0] = new int[] { 1, 2 };
            tj[1] = new int[] { 3 };
            tj[2] = new int[4];
            tj[2][0] = 4;
            tj[2][1] = 5;
            tj[2][2] = 6;
            tj[2][3] = 7;
            tj[3] = new int[2];
            tj[3][0] = 8;
            tj[3][1] = 9;

            // Lista
            // Előny: nem kell előre megmondani hány elemű legyen, dinamikus a mérete.
            // Hátrány: elem lekérdezése lassabb.
            List<int> list = new List<int>();
            //hozzáadás (lista végéhez)
            int integerÉrték = 54;
            list.Add(1);
            list.Add(integerÉrték);

            //indexelés ugyan úgy mint a tömbnél
            int listaElsőEleme = list[0];
            //méret lekérdezése
            int listaMérete = list.Count;

            // törlés index alapján
            list.RemoveAt(0);
            // törlés érték alapján
            list.Remove(integerÉrték);

            //egyéb hasznos metódusok
            list.Clear(); // lista minden elemének eldobása
            list.AddRange(list);
            list.Insert(0, integerÉrték); //érték beszúrása a lista elejére
            // list.Contains -> Eldöntés progtétel

            // KIVÉTELKEZELÉS EXCEPTION HANDLING
            // Exception -> ősosztálya az összes kivétel típusnak a C#-ban
            while (true)
            {
                try
                {
                    Console.Write($"Adj meg egy számot [{float.MinValue};{float.MaxValue}]: ");
                    string? input = Console.ReadLine();

                    float a = float.Parse(input); // Exceptiont fog dobni mivel "a" nem átalakítható integerré.
                    Console.WriteLine("Sikeres átalakítás: " + a);
                    //throw new InvalidProgramException("ASDASDASDASd");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("FormatException: " + ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("ArgumentNullException: " + ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("OverflowException: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nem várt exception: " + ex.Message);
                    throw;
                }
                finally
                {

                }
            }


        }
    }
}