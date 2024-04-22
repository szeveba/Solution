using Ensz;

namespace EnszKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context();
            c.Városok.RemoveRange(c.Városok);
            c.SaveChanges();
            //Hozzáadás
            Város varos = new Város()
            {
                ID = Guid.NewGuid().ToString("N"),
                Név = "TesztVáros",
                Népesség = 100,
            };
            c.Városok.Add(varos);
            c.SaveChanges();
            //Törlés
            //c.Városok.Remove(varos);
            //c.SaveChanges();
            //Módosítás
            varos.Név = "tesztvaros";
            c.SaveChanges();
            //Reláció
            var orszag = new Ország()
            {
                ID = Guid.NewGuid().ToString("N"),
                Főváros = varos,
                Népesség = 100,
                Terület = 100,
                Név = "TesztOrszág"
            };
            c.Országok.Add(orszag);
            c.SaveChanges();
            string asd = ";sadasd";
        }
    }
}
