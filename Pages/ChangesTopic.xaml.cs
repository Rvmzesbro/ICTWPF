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
    /// Логика взаимодействия для ChangesTopic.xaml
    /// </summary>
    public partial class ChangesTopic : Page
    {
        public chatroom ContextChatroom { get; set; }
        public ChangesTopic(chatroom chatroom)
        {
            InitializeComponent();
            ContextChatroom = chatroom;
        }

        public ChangesTopic()
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var TopicUser = NewTopic.Text;
            ContextChatroom.Topic = TopicUser;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
