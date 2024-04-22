using BookRentalFinal.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookRentalFinal.ViewModel
{
    internal class BookBrowserPageVM : ObservableRecipient
    {
        public BookBrowserPageVM()
        {
            DisplayedBooks = new ObservableCollection<Book>();
        }
        public ObservableCollection<Book> DisplayedBooks { get; private set; }
        private Book? selectedBook;

        public Book? SelectedBook
        {
            get { return selectedBook; }
            set { SetProperty(ref selectedBook, value); }
        }

        private string? searchPhrase;

        public string? SearchPhrase
        {
            get { return searchPhrase; }
            set { SetProperty(ref searchPhrase, value); }
        }
        public ICommand CMD_NewBook { get; }
        public ICommand CMD_EditBook { get; }
        public ICommand CMD_DeleteBook { get; }
    }
}
