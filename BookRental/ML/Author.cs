namespace BookRental.ML
{
    internal class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public string? Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
