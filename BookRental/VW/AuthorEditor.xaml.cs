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
    /// Interaction logic for AuthorEditor.xaml
    /// </summary>
    public partial class AuthorEditor : Window
    {
        public AuthorEditor()
        {
            InitializeComponent();
        }

        public Author? Author { get; set; }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Author == null)
            {
                Author = new Author() { Name = TBName.Text };
            }
            else if (Author.Name != TBName.Text)
            {
                Author.Name = TBName.Text;
                DialogResult = true;
            }
            Close();
        }

        private void TBTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(TBName.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Author != null)
            {
                TBName.Text = Author.Name;
            }
        }
    }
}
