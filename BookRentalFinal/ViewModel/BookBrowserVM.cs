using BookRentalFinal.BusinessLogic;
using BookRentalFinal.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookRentalFinal.ViewModel
{
    internal partial class BookBrowserVM : ObservableRecipient
    {
        private MainLogic logic;
        public BookBrowserVM()
        {
            this.logic = new MainLogic();
            ListedBooks = new ObservableCollection<Book>();
            this.PropertyChanged += BookBrowserVM_PropertyChanged;
            logic.BookSearch(searchPhrase, ListedBooks);
        }

        private void BookBrowserVM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedBook):
                    break;
                case nameof(SearchPhrase):
                    logic.BookSearch(SearchPhrase, ListedBooks);
                    break;
                default:
                    break;
            }
        }

        [ObservableProperty]
        private string? searchPhrase;

        [ObservableProperty]
        private Book? selectedBook;

        public ObservableCollection<Book> ListedBooks { get; }

        [RelayCommand]
        private void CMD_Delete()
        {
            if (SelectedBook != null)
            {
                logic.DeleteBookRequest(SelectedBook, ListedBooks);
            }
        }
        [RelayCommand]
        private void CMD_New()
        {
            
        }
    }
}
