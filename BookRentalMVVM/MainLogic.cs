using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace BookRentalMVVM
{
    internal class MainLogic
    {
        public MainLogic()
        {
            books = new List<Book>();
        }
        private const string bookDBPath = "books.csv";
        private readonly List<Book> books;

        internal void LoadBooks(ObservableCollection<Book> books)
        {
            if (File.Exists(bookDBPath))
            {
                books.Clear();
                var lines = File.ReadAllLines(bookDBPath);
                foreach (var line in lines)
                {
                    var book = Book.FromCsv(line);
                    books.Add(book);
                    this.books.Add(book);
                }
            }
            else
            {
                File.Create(bookDBPath);
            }
        }
        internal void SaveBook(Book book, ObservableCollection<Book> listedBooks)
        {
            if (!books.Contains(book))
            {
                books.Add(book);
                listedBooks.Add(book);
            }
            Save();
        }
        private void Save()
        {
            var op = new List<string>();
            foreach (var book in this.books)
            {
                op.Add(book.ToCsv());
            }
            File.WriteAllLines(bookDBPath, op);
        }
        internal void DeleteBook(Book? book, ObservableCollection<Book> listedBooks)
        {
            var result = MessageBox.Show("Biztos, hogy törölni kívánja a kiválasztott könyvet?", "Törlés...", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                books.Remove(book);
                listedBooks.Remove(book);
            }
        }

        internal void Search2(string? searchPhrase, ObservableCollection<Book> listedBooks)
        {
            var list = new List<Book>();
            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                list = books;
            }
            else
            {
                foreach (var book in this.books)
                {
                    if (book.DisplayedName!.Contains(searchPhrase))
                    {
                        list.Add(book);
                    }
                }
            }
            listedBooks.Clear();
            foreach (var item in list)
            {
                listedBooks.Add(item);
            }
        }
        internal void Search(string? searchPhrase, ObservableCollection<Book> listedBooks)
        {
            IEnumerable<Book> list;
            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                list = books;
            }
            else
            {
                //LINQ 
                list = books.Where(book => book.DisplayedName.Contains(searchPhrase));
                //books.Where()
                //IOrderedEnumerable<Book> könyvekRendezveCímSzerint = books.OrderBy(x => x.Title); books.OrderByDescending()
                //IEnumerable<string?> könyvcímek = books.Select(x => x.Title);
                //IEnumerable<IGrouping<string?, Book>> könyvcsoportokSzerzőkSzerint = books.GroupBy(x => x.Author);
                //books.Count();
            }
            listedBooks.Clear();
            foreach (var item in list)
            {
                listedBooks.Add(item);
            }
        }


    }
}
