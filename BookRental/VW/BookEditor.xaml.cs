using BookRental.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookRental.VW
{
    /// <summary>
    /// Interaction logic for BookEditor.xaml
    /// </summary>
    public partial class BookEditor : Window
    {
        public Book? Book { get; set; }
        public BookEditor()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Book == null)
            {
                Book = new Book() { Title = TBTitle.Text };
            }
            else
            {
                Book.Title = TBTitle.Text;
            }
            Close();
        }

        private void TBTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(TBTitle.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Book != null)
            {
                TBTitle.Text = Book.Title;
            }
        }
    }
}
