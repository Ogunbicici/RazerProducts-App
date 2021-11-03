using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace NewCompanyApp
{
    /// <summary>
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        RazerProductsCls RazerProducts = new RazerProductsCls();

        OpenFileDialog ofd = new OpenFileDialog();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            ofd.InitialDirectory = "c:";
            ofd.ShowDialog();

            string[] RazerProductsarray;

            dt.Columns.Add("Product Name", typeof(string));
            dt.Columns.Add("Type of Product", typeof(string));
            dt.Columns.Add("In Stock", typeof(bool));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Release Date", typeof(DateTime));


            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                while (!sr.EndOfStream)
                {

                    RazerProductsarray = sr.ReadLine().Split(";");

                    RazerProducts.Name = RazerProductsarray[0];
                    RazerProducts.Type = RazerProductsarray[1];
                    RazerProducts.InStock = Convert.ToBoolean(RazerProductsarray[2]);
                    RazerProducts.Price = Convert.ToDecimal( RazerProductsarray[3]);
                    RazerProducts.ReleaseDate = Convert.ToDateTime( RazerProductsarray[4]);

                    dt.Rows.Add(RazerProductsarray);

                    DataView dv = new DataView(dt);
                    AllProductsGrid.ItemsSource = dv;
                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using(StreamWriter sw = new StreamWriter(ofd.FileName,true))
            {
                RazerProducts.Name = NameInput.Text;
                RazerProducts.Type = PriceInput.Text;
                
                RazerProducts.Price = Convert.ToDecimal( PriceInput.Text);
                RazerProducts.ReleaseDate = Convert.ToDateTime( ReleaseDatepicker.Text);


                if (InstockOrNot.SelectedItem == Yes)
                {
                    RazerProducts.InStock = Convert.ToBoolean("TRUE");
                }
                else
                {
                    RazerProducts.InStock = Convert.ToBoolean("FALSE");
                }

                if (MouseOrKeyboard.SelectedItem == keyboard)
                {
                    RazerProducts.Type = "keyboard";
                }
                else
                {
                    RazerProducts.Type = "mouse";
                }
                //als dit niet werkt gebruik gwn de inputs!
                sw.WriteLine($"{RazerProducts.Name};{RazerProducts.Type};{RazerProducts.InStock};{RazerProducts.Price};{ReleaseDatepicker.SelectedDate}");

                dt.Rows.Add(RazerProducts.Name, RazerProducts.Type, RazerProducts.InStock, RazerProducts.Price, ReleaseDatepicker.SelectedDate);


            }

        }
    }
}
