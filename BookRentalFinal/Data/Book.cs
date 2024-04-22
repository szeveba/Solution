using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalFinal.Data
{
    // eager loading vs lazy loading
    class Book : ObservableEntity
    {
        public Book()
        {
            Authors = new ObservableCollection<Author>();
            Genres = new ObservableCollection<Genre>();
            Rents = new ObservableCollection<Rent>();
        }
        [Required, StringLength(100, MinimumLength = 1)]
        private string? name;

        public string? Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public virtual ICollection<Author> Authors { get; }
        public virtual ICollection<Genre> Genres { get; }
        public virtual ICollection<Rent> Rents { get; }
        private DateTime? published;

        public DateTime? Published
        {
            get { return published; }
            set { SetProperty(ref published, value); }
        }
    }
    class Customer : PersonEntity
    {
        public Customer()
        {
            Rents = new ObservableCollection<Rent>();
        }
        [Required, StringLength(20, MinimumLength = 1)]
        public string? Identifier { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
    class Rent : ObservableEntity
    {
        [Required]
        public Customer? Customer { get; set; }
        [Required]
        public Book? Book { get; set; }
        [Required]
        public DateTime? From { get; set; }
        [Required]
        public DateTime? Until { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
