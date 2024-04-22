using System.Collections.ObjectModel;

namespace BookRentalFinal.Data
{
    class Author : PersonEntity
    {
        public Author()
        {
            Books = new ObservableCollection<Book>();
        }
        public virtual ICollection<Book> Books { get; set; }
    }
}
