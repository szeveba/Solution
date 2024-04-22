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

namespace BingoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        private int[,] values;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var randoms = new List<int>();

            /*Töltse fel véletlenszerűen ismétlődések nélkül az oszlopokban lévő beviteli mezőket a következő értéktartományokból:
                o 1. oszlop: 1-15,
                o 2. oszlop: 16-30,
                o 3. oszlop: 31-45,
                o 4. oszlop: 46-60,
                o 5. oszlop: 61-75*/
            values = new int[5, 5];
            for (int colIdx = 0; colIdx < 5; colIdx++)
            {
                int min = 0;
                int max = 0;
                switch (colIdx)
                {
                    case 0: min = 1; max = 16; break;
                    case 1: min = 16; max = 31; break;
                    case 2: min = 31; max = 46; break;
                    case 3: min = 46; max = 60; break;
                    case 4: min = 61; max = 76; break;
                }
                for (int rowIdx = 0; rowIdx < 5; rowIdx++)
                {
                    var num = 0;
                    while (num == 0)
                    {
                        num = rnd.Next(min, max);
                        if (randoms.Contains(num)) num = 0;
                        else randoms.Add(num);
                    }
                    values[rowIdx, colIdx] = num;
                }
            }

            G.Children.Clear();
            for (int rowIdx = 0; rowIdx < 5; rowIdx++)
            {
                for (int colIdx = 0; colIdx < 5; colIdx++)
                {
                    var tb = new TextBox() { Margin = new Thickness(5) };
                    if (colIdx == 2 && rowIdx == 2)
                    {
                        tb.Text = "X";
                        tb.IsEnabled = false;
                    }
                    else
                    {
                        tb.Text = values[rowIdx, colIdx].ToString();
                    }
                    G.Children.Add(tb);
                    Grid.SetColumn(tb, colIdx);
                    Grid.SetRow(tb, rowIdx);
                }
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int rowIdx = 0; rowIdx < 5; rowIdx++)
            {
                sb.Append(values[rowIdx, 0].ToString());
                for (int colIdx = 1; colIdx < 5; colIdx++)
                {
                    sb.Append(';');
                    if (colIdx == 2 && rowIdx == 2)
                    {
                        sb.Append("X");
                    }
                    else
                    {
                        sb.Append(values[rowIdx, colIdx].ToString());
                    }
                }
                sb.AppendLine();
            }
            File.WriteAllText(TBName.Text, sb.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var gridLength = new GridLength(30);
            for (int i = 0; i < 5; i++)
            {
                G.RowDefinitions.Add(new RowDefinition() { Height = gridLength });
                G.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
            }
        }
    }
}