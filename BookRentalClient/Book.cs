using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalClient
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? Release { get; set; }
        public string? Type { get; set; }

        internal static Book FromCsv(string line)
        {
            string[] splits = line.Split('|');
            Book book = new Book();
            book.Title = splits[0];
            book.Author = splits[1];
            book.Type = splits[2];
            book.Release = DateTime.Parse(splits[3]);
            return book;
        }
        
        public string ToCsv()
        {
            return $"{Title}|{Author}|{Type}|{Release}";
        }

        public override string ToString()
        {
            return $"{Author} - {Title}";
        }
    }
}
