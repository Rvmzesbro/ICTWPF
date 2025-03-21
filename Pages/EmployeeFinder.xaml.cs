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

namespace ICT.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeFinder.xaml
    /// </summary>
    public partial class EmployeeFinder : Page
    {
        public EmployeeFinder()
        {
            InitializeComponent();
        }

        

        private void InputElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search.Text))
            {
                Search.Text = "search employee";
            }
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Search.Text == "search employee")
            {
                Search.Text = "";
            }
        }
    }
}
