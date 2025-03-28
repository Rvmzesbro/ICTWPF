﻿using ICT.Models;
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
        public  employee EmployeeContext {  get; set; }
        public chatroom ChatroomContext { get; set; }
        
        public Main(employee employee)
        {
            InitializeComponent();
            EmployeeContext = employee;
            Refresh();
        }

        private void Refresh()
        {
            DGName.Text = $"Hello {EmployeeContext.Name}!";
            DGChat.ItemsSource = App.db.members.Where(p => p.Employee_Id == EmployeeContext.Id).ToList().Select(x => x.chatroom).ToList();
        }

        private void Button_CloseApplication(object sender, RoutedEventArgs e)
        {
            App.MainWindow.Close();
        }

        private void Button_EmployeeFinder(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeFinder(null));
        }

       

        private void DGChat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DGChat.SelectedItem is chatroom chatroom)
            {
                NavigationService.Navigate(new ChatWindow(chatroom, EmployeeContext));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
