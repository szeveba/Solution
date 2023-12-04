namespace Ultrabalaton
{
    internal class Program
    {
        const int NévIndex = 0;
        const int RajtszámIndex = 1;
        const int KategóriaIndex = 2;
        const int VersenyIdő = 3;
        const int TávSzázalékIndex = 4;
        /// <summary>
        /// Feladat megoldások kiíratására.
        /// </summary>
        /// <param name="feladatSorszám">Feladat sorszáma</param>
        /// <param name="megoldás">A megoldás szövege</param>
        static void MegoldásKiiratás(int feladatSorszám, string megoldás)
        {
            Console.WriteLine($"{feladatSorszám}. feladat: {megoldás}");
        }
        /// <summary>
        /// Bementi adatok előfeldolgozása a későbbi optimálisabb munka érdekében.
        /// </summary>
        /// <param name="fájlnév">Relatív elérési út</param>
        /// <returns>Bemeneti adatok feldarabolva, fejléc nélkül</returns>
        static string[][] FájlBeolvasás(string fájlnév)
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
        static void Feladat3(string[][] adatok)
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
        static void Main(string[] args)
        {
            var adatok = FájlBeolvasás("ub2017egyeni.txt");
            Feladat3(adatok);
            Feladat4(adatok);
        }

    }
}