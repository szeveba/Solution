using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookRental.ML
{
    public class Book
    {
        public string? ID { get; set; }
        public Book()
        {
            ID = Guid.NewGuid().ToString();
            Authors = new List<Book>();
            Categories = new List<Category>();
        }
        public string? Title { get; set; }
        public List<Book> Authors { get; set; }
        public List<Category> Categories { get; set; }
        public override string ToString()
        {
            return Title ?? "";
        }
        public string ToCSV()
        {
            return $"{ID}|{Title}";
        }
        public static Book FromCsv(string csvLine)
        {
            var splits = csvLine.Split('|');
            return new Book() { ID = splits[0], Title = splits[1] };
        }
        
    }
}
