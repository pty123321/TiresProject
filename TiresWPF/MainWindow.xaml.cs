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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TiresWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReathBaseEntities Database = new ReathBaseEntities();

        List<Product> products = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
        }
       


        private void Srch_Click(object sender, RoutedEventArgs e)

        {
            string nameSearch = textBoxLogin.Text;
            MessageBox.Show("Поиск произведен!");
            string searchTerm = textBoxLogin.Text;
            var query = Database.Product.Where(x => x.Title.Contains(searchTerm));

            products.Clear();
            foreach (var item in query) 
            {
                int resultLev = CalcLevenshteinDistance(textBoxLogin.Text, item.Title);
                if (resultLev <= 10)
                {
                    products.Add(item);
                }
                    
            }
            Window1 Window = new Window1(products);
            Window.Show();
        }

        private static int CalcLevenshteinDistance(string a, string b)
        {
            if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
            {
                return 0;
            }
            if (String.IsNullOrEmpty(a))
            {
                return b.Length;
            }
            if (String.IsNullOrEmpty(b))
            {
                return a.Length;
            }
            int lengthA = a.Length;
            int lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
                for (int j = 1; j <= lengthB; j++)
                {
                    int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost
                        );
                }
            return distances[lengthA, lengthB];
        }

    }


}

