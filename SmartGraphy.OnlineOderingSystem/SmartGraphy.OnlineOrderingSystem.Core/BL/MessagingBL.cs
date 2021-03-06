﻿using System;
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
        public List<MessagingEntity> GetAllMessages(string username)
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

                                Attachments = (from x in EntityManager.TB_UserMsg_Attachments
                                               where x.username == d.TB_UserMessage.SentBy
                                               select new MessageAttachmentsEntity()
                                               {
                                                   AttachmentLocation = x.location
                                               }).ToList()
                            }).ToList();
            return messages;
        }
        public List<MessagingEntity> GetAllSentMessages(string username)
        {
            var e = EntityManager;

            var messages = (from d in EntityManager.TB_UserMessages
                            where d.SentBy == username
                            select new MessagingEntity()
                            {

                                MsgNo = d.MsgNo,
                                MsgTitle = d.MsgTitle,
                                MsgContent = d.MsgContent,
                                SentBy = d.SentBy,
                                SentOn = d.SentOn,
                                IsRead = d.IsRead,
                                Reciever = (from x in d.TB_userMessagersRecievers
                                            where x.TB_UserMessage.MsgNo == d.MsgNo
                                            select
                                            new EmployeeEntity()
                                            {
                                                FName=x.TB_User.TB_Employee.FirstName,
                                                LName = x.TB_User.TB_Employee.LastName,
                                                AdLine1 = x.TB_User.TB_Employee.AdLine1,
                                                AdLine2 = d.TB_User.TB_Employee.AdLine2,
                                                AdLine3 = d.TB_User.TB_Employee.AdLine3,
                                                ContactNo = d.TB_User.TB_Employee.ContactNo,
                                                Email = x.TB_User.TB_Employee.Email,
                                                NicNo = x.TB_User.TB_Employee.NIC,
                                                PhotoPath = x.TB_User.TB_Employee.ImgPath,
                                                Password = x.TB_User.Password,
                                                UserType = x.TB_User.UserType
                                            }
                                            ).ToList(),
                                //      select


                                //}).ToList(),
                                Attachments = (from x in EntityManager.TB_UserMsg_Attachments
                                               where x.username == username
                                               select new MessageAttachmentsEntity()
                                               {
                                                   AttachmentLocation = x.location
                                               }).ToList()
                            }).Distinct().ToList();
            return messages;

        }
    public void SendMessage(string sender, string[] recievers, string title, string message)
    {
        var msg = new TB_UserMessage
        {
            MsgContent = message,
            MsgTitle = title,
            SentBy = sender,
            SentOn = DateTime.Now,
            IsRead = false,


        };

        EntityManager.TB_UserMessages.InsertOnSubmit(msg);
        EntityManager.SubmitChanges();

        foreach (var reciever in recievers)
        {
            EntityManager.TB_userMessagersRecievers.InsertOnSubmit(new TB_userMessagersReciever()
            {
                MsgNo = msg.MsgNo,
                username = reciever
            });
        }
        //EntityManager.TB_userMessagersRecievers.InsertOnSubmit(new TB_userMessagersReciever()
        //{

        //    TB_UserMessage = new TB_UserMessage()
        //    {
        //        MsgContent = message,
        //        MsgTitle = title,
        //        SentBy = sender,
        //        SentOn = DateTime.Now,
        //        IsRead = false
        //    },
        //    username = reciever

        //});
        EntityManager.SubmitChanges();
    }
    public void ChangeMessageStatus(int msgNo)
    {
        var message = (from d in EntityManager.TB_UserMessages
                       where d.MsgNo == msgNo
                       select d).SingleOrDefault();
        message.IsRead = true;
        EntityManager.SubmitChanges();

    }
}
}
