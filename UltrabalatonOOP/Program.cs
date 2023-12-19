namespace UltrabalatonOOP;

class Program
{
    static void Main(string[] args)
    {
        var sorok = File.ReadAllLines("ub2017egyeni.txt");
        var versenyzok = new Versenyzo[sorok.Length - 1];
        for (int i = 1; i < sorok.Length; i++)
        {
            var splits = sorok[i].Split(';');
            versenyzok[i - 1] = new Versenyzo(splits[0], int.Parse(splits[1]), splits[2], splits[3], int.Parse(splits[4]));
        }
        Console.WriteLine($"3. feladat: Egyéni indulók: {versenyzok.Length} fő");
        var noiBefutok = new List<Versenyzo>();
        foreach (var versenyzo in versenyzok)
        {
            if (versenyzo.Kategoria == "Noi" && versenyzo.TavotTeljesito)
            {
                noiBefutok.Add(versenyzo);
            }
        }
        Console.WriteLine($"4. feladat: Célba érkező női sportolók: {noiBefutok.Count} fő");
        Console.Write("5. feladat: Kérem a sportoló nevét: ");
        var nevBemenet = Console.ReadLine();
        int idx = 0;
        while (idx < versenyzok.Length && !(versenyzok[idx].Nev == nevBemenet))
        {
            idx++;
        }
        Console.Write("\tIndult egyéniben a sportoló? ");
        if (idx < versenyzok.Length)
        {
            Console.WriteLine("Igen");
            var versenyzo = versenyzok[idx];
            //Console.WriteLine($"\tTeljesítette a teljes távot? {(versenyzok[idx].TavSzazalek == 100 ? "Igen" : "Nem")}");
            Console.WriteLine($"\tTeljesítette a teljes távot? {(versenyzok[idx].TavotTeljesito ? "Igen" : "Nem")}");
        }
        else
        {
            Console.WriteLine("Nem");
        }

        var versenyzok2 = File.ReadAllLines("ub2017egyeni.txt").Skip(1).Select(x => x.Split(';'))
            .Select(splits => new Versenyzo(splits[0], int.Parse(splits[1]), splits[2], splits[3], int.Parse(splits[4])))
            .ToDictionary(x => x.Nev);
        var f3 = versenyzok2.Count;
        var f4 = versenyzok2.Values.Count(x => x.Kategoria == "Noi" && x.TavotTeljesito);
        var f5 = versenyzok2!.GetValueOrDefault(nevBemenet);
    }
}
