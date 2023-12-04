namespace Ultrabalaton
{
    internal class Program
    {
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
        static void Feladat3(string[][] adatok)
        {
            int indulókSzáma = adatok.Length;
            MegoldásKiiratás(3, $"Egyéni indulók: {indulókSzáma} fő");
        }
        static void MegoldásKiiratás(int feladatSorszám, string megoldás)
        {
            Console.WriteLine($"{feladatSorszám}. feladat: {megoldás}");
        }
        static void Main(string[] args)
        {
            var adatok = FájlBeolvasás("ub2017egyeni.txt");
            Feladat3(adatok);

        }
    }
}