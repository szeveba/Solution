namespace BookRental.ML
{
    internal class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }
        public string? Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
