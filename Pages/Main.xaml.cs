using ICT.Models;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public employee EmployeeContext {  get; set; }
        
        public Main(employee employeeContext)
        {
            InitializeComponent();
            EmployeeContext = employeeContext;
            Refresh();
        }

        private void Refresh()
        {
            DGName.Text = $"Hello {EmployeeContext.Name}!";
            DGChat.ItemsSource = App.db.chatroom.ToList();
        }

        private void Button_CloseApplication(object sender, RoutedEventArgs e)
        {
            App.MainWindow.Close();
        }

        private void Button_EmployeeFinder(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeFinder());
        }

        private void SelectingItemsControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DGChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.MainWindow.MainFrame.Navigate(new ChatWindow());
        }
    }
}
