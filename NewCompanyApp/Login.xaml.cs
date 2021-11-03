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

namespace NewCompanyApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();

        }
        //hier maken we een public string username waar we later de user zijn naam in bewaren
        public string userName;

        //hier maken we een bool loggedIn die staat automatisch op false.
        public bool loggedInSucces;

        //methode maken waar we checken als de password correct is ingevuld als dat het geval is zetten we de loggedInSucces bool op true.
        public void isloggedIn()
        {
            
            if (passwordInput.Text.ToLower() == "admin")
            {
                loggedInSucces = true;
                MessageBox.Show("Logged Successfully");               
            }
            else
            {
                loggedInSucces = false;
                MessageBox.Show("Login Failed!");
            }
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //hier zeggen we dat de userName gelijk is aan de user zijn input(naam,usernaam)
            userName = UsernameInput.Text;
  
            isloggedIn();
            //zodra we op inloggen klikken hiden we deze window.
            this.Hide();
            //hier geven de userName en loggedInSucces mee naar de volgende scherm dit geval de MainWindow.
            MainWindow mw = new MainWindow(userName,loggedInSucces);
            mw.Show();
        }
    }
}
