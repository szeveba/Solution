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

namespace WPFDemo1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LB.Items.Add(TB.Text);
            TB.Clear();
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TB.Text = (string)LB.SelectedItem;
        }

        private void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LB.SelectedItem != null)
            {
                LB.SelectedValue = TB.Text;
            }
        }

        const string saveFileName = "savefile";

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var op = new List<string>();
            foreach (string item in LB.Items)
            {
                op.Add(item);
            }
            File.WriteAllLines(saveFileName, op);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(saveFileName))
            {
                var input = File.ReadAllLines(saveFileName);
                foreach (var item in input)
                {
                    LB.Items.Add(item);
                }
            }

        }
    }
}
