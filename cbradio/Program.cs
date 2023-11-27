using System.IO.Pipes;

namespace cbradio
{
    internal class Program
    {
        static int AtszamolPercre(int hour, int minute)
        {
            return hour * 60 + minute;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("cb.txt");
            int dataRowsCount = lines.Length - 1;
            Console.WriteLine($"3. feladat: Bejegyzések száma: " + dataRowsCount + " db");
            int idx = 1;
            while (idx < lines.Length && !(lines[idx].Split(';')[2] == "4"))
            {
                idx = idx + 1;
            }
            if (idx < lines.Length)
            {
                Console.WriteLine("4. feladat: Volt négy adást indító sofőr.");
            }
            else
            {
                Console.WriteLine("4. feladat: Nem volt négy adást indító sofőr.");
            }
            Console.Write("5. feladat: Kérek egy nevet: ");
            string userInputName = Console.ReadLine();
            idx = 1;
            while (idx < lines.Length && !(lines[idx].Split(';')[3] == userInputName))
            {
                idx = idx + 1;
            }
            if (idx < lines.Length)
            {
                int db = 0;
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] splits = lines[i].Split(";");
                    if (splits[3] == userInputName)
                    {
                        db = db + int.Parse(splits[2]);
                    }
                }
                Console.WriteLine("\t" + userInputName + " " + db + "x használta a CB-rádiót.");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen nevű sofőr!");
            }
            string[] opLines = new string[lines.Length];
            opLines[0] = "Kezdes;Nev;AdasDb";
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splits = lines[i].Split(';');
                int hour = int.Parse(splits[0]);
                int minute = int.Parse(splits[1]);
                opLines[i] = AtszamolPercre(hour, minute) + ";" + splits[3] + ";" + splits[2];
            }
            File.WriteAllLines("cb2.txt", opLines);
            List<string> names = new List<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                string name = lines[i].Split(';')[3];
                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }
            Console.WriteLine("8. feladat: Sofőrök száma: " + names.Count + " fő");
            int[] counts = new int[names.Count];
            for (int i = 0; i < names.Count; i++)
            {
                for (int i2 = 1; i2 < lines.Length; i2++)
                {
                    string[] splits = lines[i2].Split(";");
                    if (splits[3] == names[i])
                    {
                        counts[i] = counts[i] + int.Parse(splits[2]);
                    }
                }
            }
            int maxIdx = 0;
            for (int i = 1; i < counts.Length; i++)
            {
                if (counts[maxIdx] < counts[i])
                {
                    maxIdx = i;
                }
            }
            Console.WriteLine("9. feladat: Legtöbb adást indító sofőr");
            Console.WriteLine("\tNév: " + names[maxIdx]);
            Console.WriteLine("\tAdások száma: " + counts[maxIdx] + " alkalom");
            Console.WriteLine("Bezáráshoz nyomja meg az entert!");
            Console.ReadLine();
        }
    }
}