namespace Ultrabalaton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("ub2017egyeni.txt");
            var splits = new string[lines.Length - 1][];
            for (int i = 1; i < lines.Length; i++)
            {
                splits[i - 1] = lines[i].Split(';');
            }
            Console.WriteLine($"3. feladat: Egyéni indulók: {splits.Length} fő");
        }
    }
}