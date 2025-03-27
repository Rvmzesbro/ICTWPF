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
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Page
    {

        public long _chatId;
        public chatroom ContextChatroom { get; set; }

        public ChatWindow(chatroom chatroom)
        {
            InitializeComponent();
            _chatId = chatroom.Id;
            ContextChatroom = chatroom;
            LVMessage.ItemsSource = App.db.chatmessage.Where(p => p.Chatroom_Id == _chatId).ToList();

            LVMembers.ItemsSource = App.db.members.Where(p => p.Chatroom_Id == _chatId).ToList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            App.MainWindow.MainFrame.Navigate(new EmployeeFinder(ContextChatroom));
            
        }

        private void Change_Topic(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangesTopic(ContextChatroom));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
