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
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Page
    {

        public long _chatId;
        public chatroom ContextChatroom { get; set; }
        public employee ContextEmployee { get; set; }

        public ChatWindow(chatroom chatroom, employee employee)
        {
            InitializeComponent();
            _chatId = chatroom.Id;
            ContextChatroom = chatroom;
            ContextEmployee = employee;
            Refresh();
            
        }

        private void Refresh()
        {
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

        private void Button_Send(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Text;
            chatmessage chatmessage = new chatmessage { Sender_Id = ContextEmployee.Id, Chatroom_Id = _chatId, Date = DateTime.Now, Message = message};
            
            App.db.chatmessage.Add(chatmessage);
            App.db.SaveChanges();
            Refresh();

        }

        private void Leave_Chatroom(object sender, RoutedEventArgs e)
        {
            var member = App.db.members.FirstOrDefault(p => p.Chatroom_Id == _chatId && p.Employee_Id == ContextEmployee.Id);
            App.db.members.Remove(member);
            App.db.SaveChanges();
            NavigationService.Navigate(new Main(ContextEmployee));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            Button_Send(sender, e);
        }
    }
}
