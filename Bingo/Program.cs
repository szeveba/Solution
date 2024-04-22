namespace Bingo
{
    class BingoJatekos
    {
        public BingoJatekos(string név, string[] táblaSorok)
        {
            Név = név;
            Tábla = táblaSorok.Select(x => x.Split(';')).ToArray();
            JelölőTábla = new bool[5, 5];
            JelölőTábla[2, 2] = true;
            //Tábla = new string[5][];
            //for (int sorIdx = 0; sorIdx < 5; sorIdx++)
            //{
            //    Tábla[sorIdx] = táblaSorok[sorIdx].Split(';');
            //}
        }
        public string Név { get; set; }
        public string[][] Tábla { get; private set; }
        public bool[,] JelölőTábla { get; private set; }
        public void SorsoltSzamotJelol(int szám)
        {
            var érték = szám.ToString();
            for (int sorIdx = 0; sorIdx < 5; sorIdx++)
            {
                for (int oszlopIdx = 0; oszlopIdx < 5; oszlopIdx++)
                {
                    if (Tábla[sorIdx][oszlopIdx] == érték)
                    {
                        JelölőTábla[sorIdx, oszlopIdx] = true;
                    }
                }
            }
        }
        public void KonzolraKiíratás()
        {
            Console.WriteLine(Név);
            for (int sorIdx = 0; sorIdx < 5; sorIdx++)
            {
                for (int oszlopIdx = 0; oszlopIdx < 5; oszlopIdx++)
                {
                    if (oszlopIdx == 2 && sorIdx == 2) Console.Write("X  ");
                    else
                    {
                        if (JelölőTábla[sorIdx,oszlopIdx])
                        {
                            var érték = Tábla[sorIdx][oszlopIdx];
                            while (érték.Length < 3)
                            {
                                érték += " ";
                            }
                            Console.Write(érték);
                        }
                        else
                        {
                            Console.Write("0  ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public bool BingoEll()
        {
            //vízszintes vizsgálat
            int sorIdx = 0;
            int oszlopIdx = 0;
            while (sorIdx < 5)
            {
                while (oszlopIdx < 5 && JelölőTábla[sorIdx, oszlopIdx])
                {
                    oszlopIdx++;
                }
                if (oszlopIdx == 5) return true;
                else oszlopIdx = 0;
                sorIdx++;
            }
            //függőleges
            oszlopIdx = 0;
            sorIdx = 0;
            while (oszlopIdx < 5)
            {
                while (sorIdx < 5 && JelölőTábla[sorIdx, oszlopIdx])
                {
                    sorIdx++;
                }
                if (sorIdx == 5) return true;
                else sorIdx = 0;
                oszlopIdx++;
            }
            //balról le átló
            int i = 0;
            while (i < 5 && JelölőTábla[i, i])
            {
                i++;
            }
            if (i == 5) return true;

            //sorIdx;oszlopIdx
            // 00 01 02
            // 10 11 12
            // 20 21 22
            i = 0;
            while (i < 5 && JelölőTábla[i, 4 - i]) i++;
            if (i == 5) return true;
            else return false;
        }
    }
    internal class Program
    {
        const string forrásÚtvonal = "C:\\Users\\Szegedi Barnabás\\Downloads\\e_infoismfor_23okt_fl (1)\\Informatikai_ism_forras_E2221\\2. Programozás\\";
        static void Main(string[] args)
        {
            List<BingoJatekos> játékosok = new List<BingoJatekos>();
            var nevek = File.ReadAllLines(forrásÚtvonal + "nevek.text");
            foreach (var név in nevek)
            {
                var táblaSorok = File.ReadAllLines(forrásÚtvonal + név);
                játékosok.Add(new BingoJatekos(név.Remove(név.IndexOf('.')), táblaSorok));
            }
            Console.WriteLine("4. Feladat: Játékosok száma: " + játékosok.Count);
            Random rnd = new Random();
            Console.WriteLine("\n7. Feladat: Kihúzott számok");
            List<int> sorsoltSzámok = new List<int>();
            List<BingoJatekos> nyertesek;
            int sorszám = 1;
            do
            {
                int szám = 0;
                do
                {
                    szám = rnd.Next(1, 76);
                    if (sorsoltSzámok.Contains(szám)) szám = 0;
                    else sorsoltSzámok.Add(szám);
                }
                while (szám == 0);
                Console.Write($"{sorszám++}.->{szám}\t");

                foreach (var játékos in játékosok)
                {
                    játékos.SorsoltSzamotJelol(szám);
                }
                nyertesek = játékosok.Where(x => x.BingoEll()).ToList();
            } while (nyertesek.Count == 0);
            
            Console.WriteLine("\n");

            Console.WriteLine("8. Feladat: Lehetséges nyertes(ek):");
            foreach (var item in nyertesek)
            {
                item.KonzolraKiíratás();
            }
        }
    }
}
