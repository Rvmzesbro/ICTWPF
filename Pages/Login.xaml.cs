using ICT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace ICT.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        public employee EmployeeContext { get; set; }
        public chatroom ChatroomContext { get; set; }
        public Login()
        {
            InitializeComponent();
            EmployeeContext = new employee();
            this.Loaded += Login_Load;
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            var username = Username.Text;
            var password = Password.Text;
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                return;
            }

            else
            {
                if(Remember.IsChecked == true)
                {
                    Properties.Settings.Default.username = username;
                    Properties.Settings.Default.password = password;
                    Properties.Settings.Default.Save();
                }

                
                    EmployeeContext = App.db.employee.FirstOrDefault(p => p.Username == username && p.Password == password);
                    if (EmployeeContext != null)
                    {
                        NavigationService.Navigate(new Main(EmployeeContext));
                    }
                    else
                    {
                        return;
                    }
                
            }
        }

        private void Login_Load(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                Username.Text = Properties.Settings.Default.username;
                Password.Text = Properties.Settings.Default.password;
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            App.MainWindow.Close();
        }



        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
