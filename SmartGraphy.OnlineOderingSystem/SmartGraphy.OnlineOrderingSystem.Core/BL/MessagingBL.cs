using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class MessagingBL : AbstractBL<TB_UserMessage, long>
    {
        public List<MessagingEntity> AllMessages(string username)
        {
            var messages = (from d in EntityManager.TB_userMessagersRecievers
                            where d.username == username
                            select new MessagingEntity()
                            {
                                MsgNo = d.MsgNo,
                                MsgTitle = d.TB_UserMessage.MsgTitle,
                                MsgContent = d.TB_UserMessage.MsgContent,
                                SentBy = d.TB_UserMessage.SentBy,
                                SentOn = d.TB_UserMessage.SentOn,
                                IsRead = d.TB_UserMessage.IsRead,
                                Reciever = d.username

                            }).ToList();
            return messages;
        }
        public void sendMessage(string sender, string reciever, string title, string message)
        {
            //var TB_UserMessage = new TB_UserMessage()
            // {
            //     MsgContent = message,
            //     MsgTitle = title,
            //     SentBy = sender,
            //     SentOn = DateTime.Now,
            //     IsRead = false
            // };

            EntityManager.TB_userMessagersRecievers.InsertOnSubmit(new TB_userMessagersReciever()
            {

                TB_UserMessage = new TB_UserMessage()
                {
                    MsgContent = message,
                    MsgTitle = title,
                    SentBy = sender,
                    SentOn = DateTime.Now,
                    IsRead = false
                },
                username = reciever

            });
            EntityManager.SubmitChanges();
        }
    }
}
