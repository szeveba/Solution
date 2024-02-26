using System.Collections.ObjectModel;
using System.IO;
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
            if(!books.Contains(book))
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
            if(result == MessageBoxResult.Yes)
            {
                books.Remove(book);
                listedBooks.Remove(book);
            }
        }
    }
}
