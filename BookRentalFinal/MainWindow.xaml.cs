using BookRentalFinal.Data;
using BookRentalFinal.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookRentalFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context context;
        public MainWindow()
        {
            InitializeComponent();
            bookBrowserPage = new BookBrowserPage();
            bookBrowserPage.BTN_NewBook.Click += BookEditor_BTN_NewBook_Click;
        }

        private void BookEditor_BTN_NewBook_Click(object sender, RoutedEventArgs e)
        {
            bookEditorPage = new BookEditorPage();
            bookEditorPage.BTN_Save.Click += BookEditor_BTN_Save_Click;
            MainFrame.Content = bookEditorPage;
        }

        private void BookEditor_BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var book = (Book)bookEditorPage!.DataContext; //EntityState.Detached
                book.GenID();
                context.Books.Add(book); //EntityState.Added context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                context.SaveChanges(); //EntityState.Unchanged
                //book.Name = "asd"; //EntityState.Modified;
                //context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged; 
                //context.SaveChanges(); //EntityState.Unchanged;
                //context.Books.Remove(book); //context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private BookBrowserPage bookBrowserPage;
        private BookEditorPage? bookEditorPage;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new Context();
            MainFrame.Content = bookBrowserPage;
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = bookBrowserPage;
        }
    }
}