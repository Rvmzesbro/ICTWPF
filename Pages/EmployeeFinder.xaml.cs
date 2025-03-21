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
    /// Логика взаимодействия для EmployeeFinder.xaml
    /// </summary>
    public partial class EmployeeFinder : Page
    {
        private List<employee> employees = new List<employee>();
        public EmployeeFinder()
        {
            InitializeComponent();
            employees = App.db.employee.ToList();
            EmployeeListBox.ItemsSource = employees;
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
            // в верстке добавили DisplayMemberPath эта хрень показывает свойство Name у каждого объекта
            var TextUser = Search.Text.ToLower();
            var FoundEmployees = employees.Where(p => p.Name.ToLower().Contains(TextUser)).ToList();
            if (this.EmployeeListBox == null)
            {
                return;
            }
            EmployeeListBox.ItemsSource = FoundEmployees;
        }
    }
}
