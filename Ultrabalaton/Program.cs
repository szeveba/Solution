namespace Ultrabalaton
{
    internal class Program
    {
        const int NévIndex = 0;
        const int RajtszámIndex = 1;
        const int KategóriaIndex = 2;
        const int VersenyIdőIndex = 3;
        const int TávSzázalékIndex = 4;
        static void Main(string[] args)
        {
            var adatok = FájlBeolvasás("ub2017egyeni.txt");
            Feladat3(adatok);
            Feladat4(adatok);
            Feladat5(adatok);
            Feladat7(adatok);
            Feladat8(adatok);
            OptimalizáltFeladat8(adatok);
        }
        /// <summary>
        /// Feladat megoldások kiíratására.
        /// </summary>
        /// <param name="feladatSorszám">Feladat sorszáma</param>
        /// <param name="megoldás">A megoldás szövege</param>
        private static void MegoldásKiiratás(int feladatSorszám, string megoldás)
        {
            Console.WriteLine($"{feladatSorszám}. feladat: {megoldás}");
        }
        /// <summary>
        /// Bementi adatok előfeldolgozása a későbbi optimálisabb munka érdekében.
        /// </summary>
        /// <param name="fájlnév">Relatív elérési út</param>
        /// <returns>Bemeneti adatok feldarabolva, fejléc nélkül</returns>
        private static string[][] FájlBeolvasás(string fájlnév)
        {
            var lines = File.ReadAllLines(fájlnév);
            var op = new string[lines.Length - 1][];
            for (int i = 1; i < lines.Length; i++)
            {
                op[i - 1] = lines[i].Split(';');
            }
            return op;
        }
        /// <summary>
        /// Határozza meg és írja ki a képernyőre a minta szerint, hogy hány egyéni sportoló indult el a versenyen! 
        /// </summary>
        private static void Feladat3(string[][] adatok)
        {
            int indulókSzáma = adatok.Length;
            MegoldásKiiratás(3, $"Egyéni indulók: {indulókSzáma} fő");
        }
        /// <summary>
        /// Számolja meg és írja ki a képernyőre a minta szerint, hogy hány női sportoló teljesítette a teljes távot!
        /// </summary>
        private static void Feladat4(string[][] adatok)
        {
            //megszámlálás programozási tétel alkalmazása...
            int db = 0;
            foreach (var adatsor in adatok)
            {
                if (adatsor[KategóriaIndex] == "Noi" && adatsor[TávSzázalékIndex] == "100")
                {
                    db++;
                }
            }
            MegoldásKiiratás(4, $"Célba érkező női sportolók: {db} fő");
        }
        /// <summary>
        /// Kérje be a felhasználótól egy sportoló nevét, majd határozza meg és írja ki a minta szerint, hogy a sportoló indult-e a versenyen! A keresést ne folytassa, ha az eredményt meg tudja határozni! Ha a sportoló indult a versenyen, akkor azt is írja ki a képernyőre, hogy a teljes távot teljesítette-e! Feltételezheti, hogy nem indultak azonos nevű sportolók ezen a versenyen.         
        /// </summary>
        private static void Feladat5(string[][] adatok)
        {
            Console.Write("5. feladat: Kérem a sportoló nevét: ");
            string keresettNév = Console.ReadLine();
            //eldöntés programozási tétel alkalmazása
            int i = 0;
            while (i < adatok.Length && !(adatok[i][NévIndex] == keresettNév))
            {
                i++;
            }
            Console.Write("\tIndult egyéniben a sportoló? ");
            if (i < adatok.Length)
            {
                Console.WriteLine("Igen");
                Console.Write("\tTeljesítette a teljes távot? ");
                if (adatok[i][TávSzázalékIndex] == "100")
                {
                    Console.WriteLine("Igen");
                }
                else
                {
                    Console.WriteLine("Nem");
                }
            }
            else
            {
                Console.WriteLine("Nem");
            }
        }
        /// <summary>
        /// Készítsen IdőÓrában azonosítóval valós típusú értékkel visszatérő függvényt vagy jellemzőt, ami a versenyző időeredményét órában határozza meg! Egy óra 60 percből, illetve 3600 másodpercből áll.
        /// </summary>
        /// <param name="időbélyeg">óra:perc:másodperc alakban meghatározott időbélyeg</param>
        /// <returns>időbélyeg értéke órában kifejezve</returns>
        private static double IdőÓrában(string időbélyeg)
        {
            var splits = időbélyeg.Split(':');
            int óra = int.Parse(splits[0]);
            int perc = int.Parse(splits[1]);
            int másodperc = int.Parse(splits[2]);
            return óra + perc / 60.0 + másodperc / 3600.0;
        }
        /// <summary>
        /// Határozza meg és írja ki a minta szerint a teljes távot teljesítő férfi sportolók átlagos idejét órában! Feltételezheti, hogy legalább egy ilyen sportoló volt.
        /// </summary>
        private static void Feladat7(string[][] adatok)
        {
            //megszámlálás és sorozatszámítás programozási tétel együttesen alkalmazva
            int db = 0;
            double szum = 0;
            foreach (var adatsor in adatok)
            {
                if (adatsor[KategóriaIndex] == "Ferfi" && adatsor[TávSzázalékIndex] == "100")
                {
                    db++;
                    szum += IdőÓrában(adatsor[VersenyIdőIndex]);
                }
            }
            // A feladat szerint feltételezhetem, hogy lesz legalább egy a feltételt teljesítő sportoló, így nem kell aggódni a 0-val való osztás miatt.
            double átlag = szum / db;
            MegoldásKiiratás(7, $"Átlagos idő: {Math.Round(átlag,12)} óra");
            MegoldásKiiratás(7, $"Átlagos idő: {átlag} óra");
        }
        /// <summary>
        /// Keresse meg a női és a férfi kategóriák győzteseit és írja ki nevüket, rajtszámukat és időeredményeiket a minta szerint! Feltételezheti, hogy egyik kategóriában sem alakult ki holtverseny és mindkét kategóriában volt célba érkező futó.
        /// </summary>
        private static void Feladat8(string[][] adatok)
        {
            // kiindulási alap: maximumkiválasztás programozási tétel, szerintem ezt a megoldást jobban végiggondoltam mint az aki kitalálta a feladatot, hiába azonos szerkezetű bemeneti fájl, kivételes esetben ennél egyszerűbb megoldás hibás eredményt adna (de attól még járna amúgy a max pontszám valószínűleg)
            int nőiMaxIdx = -1;
            int férfiMaxIdx = -1;
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] adatsor = adatok[i];
                if (adatsor[TávSzázalékIndex] == "100")
                {
                    if (adatsor[KategóriaIndex] == "Noi")
                    {
                        if (nőiMaxIdx == -1 || IdőÓrában(adatsor[VersenyIdőIndex]) < IdőÓrában(adatok[nőiMaxIdx][VersenyIdőIndex]))
                        {
                            nőiMaxIdx = i;
                        }
                    }
                    else
                    {
                        if (férfiMaxIdx == -1 || IdőÓrában(adatsor[VersenyIdőIndex]) < IdőÓrában(adatok[férfiMaxIdx][VersenyIdőIndex]))
                        {
                            férfiMaxIdx = i;
                        }
                    }
                }
            }
            MegoldásKiiratás(8,
                $"Verseny győztesei\n" +
                $"\tNők: {adatok[nőiMaxIdx][NévIndex]} ({adatok[nőiMaxIdx][RajtszámIndex]}.) - {adatok[nőiMaxIdx][VersenyIdőIndex]}\n" +
                $"\tFérfiak: {adatok[férfiMaxIdx][NévIndex]} ({adatok[férfiMaxIdx][RajtszámIndex]}.) - {adatok[férfiMaxIdx][VersenyIdőIndex]}");
        }
        /// <summary>
        /// Keresse meg a női és a férfi kategóriák győzteseit és írja ki nevüket, rajtszámukat és időeredményeiket a minta szerint! Feltételezheti, hogy egyik kategóriában sem alakult ki holtverseny és mindkét kategóriában volt célba érkező futó.
        /// </summary>
        private static void OptimalizáltFeladat8(string[][] adatok)
        {
            int nőiMaxIdx = NyertesKeresés(adatok, "Noi");
            int férfiMaxIdx = NyertesKeresés(adatok, "Ferfi");
            string[] nőiNyertes = adatok[nőiMaxIdx];
            string[] férfiNyertes = adatok[férfiMaxIdx];
            MegoldásKiiratás(8,
                $"Verseny győztesei\n" +
                $"\tNők: {nőiNyertes[NévIndex]} ({nőiNyertes[RajtszámIndex]}.) - {nőiNyertes[VersenyIdőIndex]}\n" +
                $"\tFérfiak: {férfiNyertes[NévIndex]} ({férfiNyertes[RajtszámIndex]}.) - {férfiNyertes[VersenyIdőIndex]}");
        }
        private static int NyertesKeresés(string[][] adatok, string kategória)
        {
            int nyertesIdx = -1;
            double nyertesIdő = double.MaxValue;
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] adatsor = adatok[i];
                if (adatsor[KategóriaIndex] == kategória && adatsor[TávSzázalékIndex] == "100")
                {
                    double aktuálisIdő = IdőÓrában(adatsor[VersenyIdőIndex]);
                    if (nyertesIdx == -1 || aktuálisIdő < nyertesIdő)
                    {
                        nyertesIdx = i;
                        nyertesIdő = aktuálisIdő;
                    }
                }
            }
            return nyertesIdx;
        }
        static int MaxKivál(int[] értékek)
        {
            int maxIdx = 0;
            for (int i = 1; i < értékek.Length; i++)
            {
                if (értékek[maxIdx] < értékek[i]) maxIdx = i;
            }
            return maxIdx;
        }
    }
}