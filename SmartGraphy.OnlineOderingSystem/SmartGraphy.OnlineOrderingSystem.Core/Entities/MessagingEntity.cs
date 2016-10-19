using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class MessagingEntity
    {
        public int MsgNo { get; set; }
        public string MsgTitle { get; set; }
        public string MsgContent { get; set; }
        public string SentBy { get; set; }
        public DateTime SentOn { get; set; }
        public bool IsRead { get; set; }
        public string Reciever{get;set;}

    }
}
