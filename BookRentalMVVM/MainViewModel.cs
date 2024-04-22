using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookRentalMVVM
{
    internal class MainViewModel : ObservableObject
    {
        private string? searchPhrase;
        private Book? book;
        private MainLogic logic;
        private bool manipulationEnabled;

        public MainViewModel()
        {
            logic = new MainLogic();
            ListedBooks = new ObservableCollection<Book>();
            logic.LoadBooks(ListedBooks);
            this.PropertyChanged += MainViewModel_PropertyChanged;
            CMD_NewBook = new RelayCommand(NewBookAction);
            CMD_SaveBook = new RelayCommand(SaveBookAction);
            CMD_DeleteBook = new RelayCommand(() =>
            {
                logic.DeleteBook(Book, ListedBooks);
            });
        }

        private void MainViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SearchPhrase):
                    logic.Search(SearchPhrase, ListedBooks);
                    break;
                case nameof(Book):
                    ManipulationEnabled = Book != null;
                    break;
                default:
                    break;
            }
        }

        public ObservableCollection<Book> ListedBooks { get; }
        public string? SearchPhrase { get => searchPhrase; set => SetProperty(ref searchPhrase, value); }
        public Book? Book
        {
            get { return book; }
            set { SetProperty(ref book, value); }
        }
        public bool ManipulationEnabled
        {
            get { return manipulationEnabled; }
            set { SetProperty(ref manipulationEnabled, value); }
        }
        public ICommand CMD_NewBook { get; }
        public ICommand CMD_SaveBook { get; }
        public ICommand CMD_DeleteBook { get; }
        private void NewBookAction()
        {
            Book = new Book();
        }
        private void SaveBookAction()
        {
            logic.SaveBook(Book!, ListedBooks);
        }

    }
}
