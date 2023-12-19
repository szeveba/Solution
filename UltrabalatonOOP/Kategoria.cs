namespace UltrabalatonOOP;

class Kategoria
{
    public Kategoria(string nev, List<Versenyzo> versenyzok)
    {
        Nev = nev;
        Versenyzok = versenyzok;
    }
    public Kategoria(string nev)
    {
        Nev = nev;
        Versenyzok = new List<Versenyzo>();
    }

    public string Nev { get; set; }
    public List<Versenyzo> Versenyzok { get; private set; }
}
