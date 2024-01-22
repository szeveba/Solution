
namespace BookRental.ML
{
    public class Author
    {
        public Author()
        {
            ID = Guid.NewGuid().ToString();
            Books = new List<Book>();
        }
        public string? ID { get; set; }
        public string? Name { get; set; }
        public List<Book> Books { get; set; }

        internal static Author FromCsv(string x)
        {
            var splits = x.Split('|');
            return new Author()
            {
                ID = splits[0],
                Name = splits[1],
            };
        }

        public string ToCSV()
        {
            return $"{ID}|{Name}";
        }

        public override string ToString()
        {
            return Name??"";
        }
    }
}
