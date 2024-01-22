using BookRental.ML;
using BookRental.VW;
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

namespace BookRental
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

        private void BookEditor_Click(object sender, RoutedEventArgs e)
        {
            BookEditor window = new BookEditor();
            window.ShowDialog();
            if (window.Book != null)
            {
                LBBooks.Items.Add(window.Book);
                File.AppendAllText(bookDBName, window.Book.ToCSV() + "\n");
                SaveDB();
            }
        }

        private void BookDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LBBooks.SelectedItem != null)
            {
                LBBooks.Items.Remove(LBBooks.SelectedItem);
                SaveDB();
            }
        }

        private void SaveDB()
        {
            var bookOP = new List<string>();
            var authorOP = new List<string>();
            foreach (Book item in LBBooks.Items)
            {
                bookOP.Add(item.ToCSV());
            }
            foreach (Author item in LBAuthors.Items)
            {
                authorOP.Add(item.ToCSV());
            }
            File.WriteAllLines(bookDBName, bookOP.ToArray());
            File.WriteAllLines(authorDBName, authorOP.ToArray());
        }

        private void LBBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookDeleteButton.IsEnabled = LBBooks.SelectedItem != null;
            BookEditButton.IsEnabled = LBBooks.SelectedItem != null;
        }

        private void BookEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenBookEditor();
            SaveDB();
        }

        private void OpenBookEditor()
        {
            if (LBBooks.SelectedItem != null)
            {
                BookEditor window = new BookEditor();
                window.Book = (Book)LBBooks.SelectedItem;
                window.ShowDialog();
                LBBooks.Items.Refresh();
            }
        }

        private void LBBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LBBooks.SelectedItem != null)
            {
                OpenBookEditor();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(bookDBName))
            {
                var books = File.ReadAllLines(bookDBName).Select(x => Book.FromCsv(x));
                foreach (var item in books)
                {
                    LBBooks.Items.Add(item);
                }
            }
            else
            {
                File.Create(bookDBName);
            }
            if (File.Exists(authorDBName))
            {
                var authors = File.ReadAllLines(authorDBName).Select(x => Author.FromCsv(x));
                foreach (var item in authors)
                {
                    LBAuthors.Items.Add(item);
                }
            }
            else
            {
                File.Create(authorDBName);
            }
        }

        const string bookDBName = "books.db";
        const string authorDBName = "authors.db";

        private void AuthorEditor_Click(object sender, RoutedEventArgs e)
        {
            AuthorEditor window = new AuthorEditor();
            window.ShowDialog();
            if (window.Author != null)
            {
                LBAuthors.Items.Add(window.Author);
                SaveDB();
            }
        }

        private void AuthorEdit_Click(object sender, RoutedEventArgs e)
        {
            AuthorEditor window = new AuthorEditor();
            window.Author = (Author)LBAuthors.SelectedItem;
            window.ShowDialog();
            LBAuthors.Items.Refresh();
            if(window.DialogResult == true)
            {
                SaveDB();
            }
        }

        private void AuthorDelete_Click(object sender, RoutedEventArgs e)
        {
            LBAuthors.Items.Remove(LBAuthors.SelectedItem);
            SaveDB();
        }

        private void LBAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AuthorEditButton.IsEnabled = LBAuthors.SelectedItem != null;
            AuthorDeleteButton.IsEnabled = LBAuthors.SelectedItem != null;
        }
    }
}