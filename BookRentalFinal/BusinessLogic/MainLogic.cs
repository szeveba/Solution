using BookRentalFinal.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookRentalFinal.BusinessLogic
{
    internal class MainLogic
    {
        private Context context;
        public MainLogic()
        {
            this.context = new Context();
        }

        internal void BookSearch(string? searchPhrase, ObservableCollection<Book> listedBooks)
        {
            listedBooks.Clear();
            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                foreach (var item in context.Books)
                {
                    listedBooks.Add(item);
                }
            }
            else
            {
                //foreach (var item in context.Books)
                //{
                //    if (item.Name!.Contains(searchPhrase))
                //    {
                //        listedBooks.Add(item);
                //    }
                //}
                foreach (var item in context.Books.Where(x => x.Name!.Contains(searchPhrase)))
                {
                    listedBooks.Add(item);
                }
                //context.Books.Where(x => x.Name!.Contains(searchPhrase)).ToList().ForEach(x=>listedBooks.Add(x));
            }
        }

        internal void DeleteBookRequest(Book selectedBook, ObservableCollection<Book> listedBooks)
        {
            var result = MessageBox.Show("Biztos törölni kívánja a kiválasztott elemet?", "Törlés...", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Books.Remove(selectedBook); //context.Entry(selectedBook).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                    listedBooks.Remove(selectedBook);
                }
                catch (Exception)
                {
                    context.Entry(selectedBook).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    MessageBox.Show("A törlés során hiba lépet fel.", "Törlés sikertelen!", MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }
    }
}
