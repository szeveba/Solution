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

namespace FramePageSample
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
            SwitchToPage1(sender, e);
        }
        private void SwitchToPage1(object sender, RoutedEventArgs e)
        {
            var page = new Page1();
            MainFrame.Content = page;
            page.BTN.Click += SwitchToPage2;
        }

        private void SwitchToPage2(object sender, RoutedEventArgs e)
        {
            var page = new Page2();
            MainFrame.Content = page;
            page.BTN.Click += SwitchToPage1;
        }
    }
}