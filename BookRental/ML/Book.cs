using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.ML
{
    internal class Book
    {
        public Book()
        {
            Authors = new List<Author>();
            Categories = new List<Category>();
        }
        public string? Title { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
