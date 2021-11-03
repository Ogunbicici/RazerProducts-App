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
    /// Interaction logic for ViewProducts.xaml
    /// </summary>
    public partial class ViewProducts : Window
    {
        public ViewProducts()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        RazerProductsCls RazerProducts = new RazerProductsCls();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
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
                    RazerProducts.Price = Convert.ToDecimal(RazerProductsarray[3]);
                    RazerProducts.ReleaseDate = Convert.ToDateTime(RazerProductsarray[4]);

                    //Hier checken we Als de Type een mouse is dan steken we het in een aparte lisbox en de rest (Keyboards) in een ander listbox.
                    if (RazerProductsarray[1] == "mouse")
                    {
                        MouseLstBox.Items.Add($"{RazerProductsarray[0]} - {RazerProductsarray[3]}€");

                    }
                    else
                    {
                        KeyboardLstBox.Items.Add($"{RazerProductsarray[0]} - {RazerProductsarray[3]}€");
                    }
                                                        
                    
                }
                
            }
            
            


        }

        
    }
}
