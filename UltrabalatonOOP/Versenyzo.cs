namespace UltrabalatonOOP;

class Versenyzo
{
    private int tavSzazalek;
    private string nev;
    public Versenyzo(string nev, int rajtszam, string kategoria, string versenyido, int tavSzazalek)
    {
        this.nev = nev;
        Rajtszam = rajtszam;
        Kategoria = kategoria;
        Versenyido = versenyido;
        TavSzazalek = tavSzazalek;
    }
    //DateOnly + TimeOnly => DateTime
    public TimeSpan VersenyIdo2 { get; set; }
    public string NemecsekNev { get => nev.ToLower(); }
    public string Nev { get => nev; set => nev = value; }
    public int Rajtszam { get; set; }
    public string Kategoria { get; set; }
    public string Versenyido { get; set; }
    public bool TavotTeljesito { get; private set; }
    public int TavSzazalek
    {
        get
        {
            return tavSzazalek;
        }
        set
        {
            tavSzazalek = value;
            TavotTeljesito = tavSzazalek == 100;
        }
    }
    public double IdoOraban()
    {
        var splits = Versenyido.Split(':');
        var ora = int.Parse(splits[0]);
        var perc = int.Parse(splits[1]);
        var masodperc = int.Parse(splits[2]);
        var op = new TimeSpan(ora, perc, masodperc);
        return op.TotalHours;
    }
}
