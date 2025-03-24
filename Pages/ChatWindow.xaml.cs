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
        public List<chatmessage> chatmessages = new List<chatmessage>();
        public ChatWindow()
        {
            InitializeComponent();
            chatmessages = App.db.chatmessage.ToList();
            //DGChat.ItemsSource = chatmessages;
            //DGMembers.ItemsSource = App.db.members.ToList();

            Refresh();
        }

        private void Refresh()
        {
            using (var context = new ICTEntities3())
            {
                var messages = context.chatmessage.OrderBy(p => p.Date).ToList();
                DGChat.ItemsSource = messages;
            }
        }
    }
}
