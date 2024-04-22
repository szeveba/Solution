using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BookRentalFinal.Data
{
    class Genre : ObservableEntity
    {
        public Genre()
        {
            Books = new ObservableCollection<Book>();
        }
        [Required, StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }
        public virtual ICollection<Book> Books { get; }
    }
}
