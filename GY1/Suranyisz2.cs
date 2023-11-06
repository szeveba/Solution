using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY1
{
    public static partial class Suranyisz
    {
        private static decimal ReadDecimal(string message = "Adj meg egy számot: ")
        {
            Console.Write(message);
            string input = Console.ReadLine();
            decimal num = 0;

            while (!decimal.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }
        private static long ReadLong(string message = "Adj meg egy számot: ")
        {
            Console.Write(message);
            string input = Console.ReadLine();
            long num = 0;

            while (!long.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }
        private static double ReadDouble(string message = "Adj meg egy számot: ")
        {
            Console.Write(message);
            string input = Console.ReadLine();
            double num = 0;

            while (!double.TryParse(input, out num))
            {
                Console.WriteLine($"Nem tudtam számként értelmezni ezt: {input}");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return num;
        }
    }
}
