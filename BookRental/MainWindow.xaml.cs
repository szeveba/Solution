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
            var op = new List<string>();
            foreach (Book item in LBBooks.Items)
            {
                op.Add(item.ToCSV());
            }
            File.WriteAllLines(bookDBName, op.ToArray());
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
                var books = File.ReadAllLines(bookDBName).Select(x=> Book.FromCsv(x));
                foreach (var item in books)
                {
                    LBBooks.Items.Add(item);
                }
            }
            else
            {
                File.Create(bookDBName);
            }
        }

        const string bookDBName = "books.db";
    }
}