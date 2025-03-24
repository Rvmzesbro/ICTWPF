using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Models
{
    public partial class chatroom
    {
        public chatmessage LastChatMessage
        {
            get
            {
                if (this.chatmessage.Count == 0)
                {
                    return null;
                }

                return chatmessage.OrderBy(p => p.Date).Last();
            }
        }
    }
}
