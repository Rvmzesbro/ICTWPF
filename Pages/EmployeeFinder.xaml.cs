using ICT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private List<employee> employees = new List<employee>();
        public employee Selectedemployee { get; set; }
        
        public chatroom chatroom { get; set; }
        public EmployeeFinder(chatroom contextChatroom)
        {
            InitializeComponent();
            employees = App.db.employee.ToList();
            EmployeeListBox.ItemsSource = employees;
            chatroom = contextChatroom;
            
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

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

            var SelectDepartments = new List<string>();

            if (CheckAdmin.IsChecked.Value)
            {
                SelectDepartments.Add("1");
            }
            if (CheckIT.IsChecked.Value)
            {
                SelectDepartments.Add("2");
            }
            if (CheckSales.IsChecked.Value)
            {
                SelectDepartments.Add("3");
            }
            if (CheckMarketing.IsChecked.Value)
            {
                SelectDepartments.Add("4");
            }

            // в верстке добавили DisplayMemberPath эта хрень показывает свойство Name у каждого объекта
            var TextUser = Search.Text.ToLower();
            var FilteredList = employees.Where(p => p.Name.ToLower().Contains(TextUser) && SelectDepartments.Contains(p.Department_Id.ToString())).ToList();

            if (this.EmployeeListBox == null)
            {
                return ;
            }
            EmployeeListBox.ItemsSource = FilteredList;
        }

        

        private void DepartmentFilterChanged(object sender, RoutedEventArgs e)
        {
            var SelectDepartments = new List<string>();

            if (CheckAdmin.IsChecked.Value)
            {
                SelectDepartments.Add("1");
            }
            if (CheckIT.IsChecked.Value)
            {
                SelectDepartments.Add("2");
            }
            if (CheckSales.IsChecked.Value)
            {
                SelectDepartments.Add("3");
            }
            if (CheckMarketing.IsChecked.Value)
            {
                SelectDepartments.Add("4");
            }

            var FilteredList = employees.Where(p => SelectDepartments.Contains(p.Department_Id.ToString())).ToList();
            
            if(this.EmployeeListBox == null)
            {
                return;
            }
            EmployeeListBox.ItemsSource = FilteredList;
        }

        

        private void EmployeeListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.chatroom == null)
            {
                return;
            }

            if (EmployeeListBox.SelectedItem is employee employee)
            {
                
                var members = new members();
                members.Employee_Id = employee.Id;
                members.Chatroom_Id = chatroom.Id;

                App.db.members.Add(members);
                App.db.SaveChanges();
                NavigationService.Navigate(new ChatWindow(chatroom));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
