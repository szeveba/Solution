using System.IO;
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

namespace BookRentalClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainPage page = new MainPage();
            MainFrame.Content = page;
        }


        /*
        private const string BookDBPath = "books.csv";

        private void NewBook_Click(object sender, RoutedEventArgs e)
        {
            BookEditorWindow window = new BookEditorWindow();
            if (window.ShowDialog() == true)
            {
                LB_Books.Items.Add(window.Book);
                Save();
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztos, hogy törölni kívánja a kiválasztott könyvet?", "Könyv törlése", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                LB_Books.Items.Remove(LB_Books.SelectedItem);
                Save();
            }
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Books.SelectedItem == null) return;
            BookEditorWindow window = new BookEditorWindow();
            window.Book = (Book)LB_Books.SelectedItem;
            if (window.ShowDialog() == true)
            {
                int index = LB_Books.SelectedIndex;
                LB_Books.Items.RemoveAt(index);
                LB_Books.Items.Insert(index, window.Book);
                LB_Books.SelectedItem = window.Book;
                Save();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(BookDBPath))
            {
                string[] lines = File.ReadAllLines(BookDBPath);
                foreach (string line in lines)
                {
                    Book book = Book.FromCsv(line);
                    LB_Books.Items.Add(book);
                }
            }
            else
            {
                File.Create(BookDBPath);
            }
        }

        private void Save()
        {
            List<string> op = new List<string>();
            foreach (Book item in LB_Books.Items)
            {
                op.Add(item.ToCsv());
            }
            File.WriteAllLines(BookDBPath, op);
        }

        private void LB_Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BTN_EditBook.IsEnabled = LB_Books.SelectedItem != null;
            BTN_DeleteBook.IsEnabled = LB_Books.SelectedItem != null;
        }

        private void LB_Books_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditBook_Click(sender, e);
        }

        private void LB_Books_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: EditBook_Click(sender, e); break;
                case Key.Delete: DeleteBook_Click(sender, e); break;
            }
        }
        */
    }
}