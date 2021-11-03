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

namespace NewCompanyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        //hier moeten we de parameters ontvangen en er iets mee doen in dit geval 
        public MainWindow(string userName, bool enableBtn)
        {
            InitializeComponent();

            //hier zetten we die inputted userName in deze label.
            UserNameLbl.Content = userName;

            //hier checken we als de bool enableBtn = is gwn de loggedInSucces bool van de vorige venster,
            //als die true is zetten we de AddProductBtn.IsEnabled op true;
            //en anders blijft die gwn false
            if (enableBtn == true)
            {
                AddProductBtn.IsEnabled = true;
            }
            else
            {
                AddProductBtn.IsEnabled = false;
            }
            
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login loginview = new Login();           
            loginview.Show();  
        }

        private void ViewProducts_Click(object sender, RoutedEventArgs e)
        {
            ViewProducts vp = new ViewProducts();
            vp.Show();

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProducts ap = new AddProducts();
            ap.Show();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
