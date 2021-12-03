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

namespace TiresWPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        //List<Product> products = new List<Product>() { 
        //    new Product(){ Title = "test title" },
        //    new Product(){ Title = "test title" },
        //    new Product(){ Title = "test title" },
        //    new Product(){ Title = "test title" },
        //    new Product(){ Title = "test title" },
        //    new Product(){ Title = "test title" },
        //};


        public Window1(List<Product> products)
        {
            InitializeComponent();
            MainListBox.ItemsSource = products;
        }
    }
}
