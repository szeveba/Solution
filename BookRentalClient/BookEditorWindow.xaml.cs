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

namespace BookRentalClient
{
    /// <summary>
    /// Interaction logic for BookEditorWindow.xaml
    /// </summary>
    public partial class BookEditorWindow : Window
    {
        public BookEditorWindow()
        {
            InitializeComponent();
        }
        public Book? Book { get; set; }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Book = new Book();
            Book.Title = TB_Title.Text.Trim();
            Book.Author = TB_Author.Text.Trim();
            Book.Type = TB_Type.Text.Trim();
            Book.Release = DP_Release.SelectedDate;
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Book != null)
            {
                TB_Title.Text = Book.Title;
                TB_Author.Text = Book.Author;
                TB_Type.Text = Book.Type;
                DP_Release.SelectedDate = Book.Release;
            }
        }

        private void Property_Changed(object sender, EventArgs e)
        {
            BTN_Save.IsEnabled = FormIsValid();
        }

        private bool FormIsValid()
        {
            try
            {
                DateTime.Parse(DP_Release.Text);
                return !string.IsNullOrWhiteSpace(TB_Title.Text)
                       && !string.IsNullOrWhiteSpace(TB_Author.Text)
                       && !string.IsNullOrWhiteSpace(TB_Type.Text);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape: Close(); break;
                case Key.Enter:
                    if (FormIsValid())
                    {
                        Save_Click(sender, e);
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void DP_Release_KeyDown(object sender, KeyEventArgs e)
        {
            string asd = "asdasd";
        }

        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox tb)
            {
                tb.CaretIndex = tb.Text.Length;
            }
        }
    }
}
