using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using SmartGraphy.OnlineOrderingSystem.Core.BL;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using System.Web.Script.Serialization;

namespace SmartGraphy.OnlineOderingSystem.WebServices
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string VerifyUser(string username, string password)
        {
            var userDetails = new UsersBL().VerifyUser(username, password);
            EmployeeEntity employeeDetails = new EmployeeEntity();
            if (userDetails != null)
            {
                employeeDetails = new UsersBL().GetUserDetailsByUsername(username);
                Session["username"] = username;
                Session["password"] = password;
                Session["fname"] = employeeDetails.FName;
                Session["lname"] = employeeDetails.LName;
                Session["usertype"] = employeeDetails.UserType;
            }
            return new JavaScriptSerializer().Serialize(employeeDetails); ;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public bool AddNewUser(string nic, string username, string type, string fname, string lname, string adline1, string adline2, string adline3, string contactno, string email, string photo)
        {

            return new UsersBL().AddNewUser(nic, username, type, fname, lname, adline1, adline2, adline3, contactno, email, photo);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string ChangeUserStatus(int option, string username)
        {
            bool result;
            if (option == 0)
            {
                result = new UsersBL().UnblockUser(username);
            }
            else
                result = new UsersBL().BlockUser(username);

            return new JavaScriptSerializer().Serialize(result);
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string ResetPassword(string username)
        {
            var result = new UsersBL().ResetPassword(username);
            return new JavaScriptSerializer().Serialize(result);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string LoadUserMessages(int option)
        {
            string html = string.Empty;
            if (option == 1)
            {
                string username = Session["username"].ToString();
                string status = string.Empty;

                var userMsgs = new MessagingBL().GetAllMessages(username);
                foreach (var msg in userMsgs)
                {
                    if (!msg.IsRead)
                    {
                        status = "<i class=\"fa fa-exclamation-circle\" aria-hidden=\"true\"></i>";
                    }
                    else
                    {
                        status = string.Empty;
                    }
                    html += "<tr id=\"" + msg.MsgNo + "\" data-date=\"" + msg.SentOn + "\" data-msg=\"" + msg.MsgContent + "\" data-sender=\"" + msg.SentBy + "\"data-title=\"" + msg.MsgTitle + "\" onClick=\"showMessage(this);\"><td>" + status + " </td><td>" + msg.MsgTitle + "</td><td>" + msg.SentBy + "</td><td>" + msg.SentOn + "</td</tr>";
                }
            }
            else
            {
                string recievers = string.Empty;
                string username = Session["username"].ToString();
                var userMsgs = new MessagingBL().GetAllSentMessages(username);
                foreach (var msg in userMsgs)
                {
                    foreach (var reciever in msg.Reciever)
                    {
                        recievers += reciever.FName + " " + reciever.LName + ",";
                    }

                    html += "<tr id=\"" + msg.MsgNo + "\" data-date=\"" + msg.SentOn + "\" data-msg=\"" + msg.MsgContent + "\" data-sender=\"" + msg.SentBy + "\"data-title=\"" + msg.MsgTitle + "\" onClick=\"showSentMessage(this);\"><td> </td><td>" + msg.MsgTitle + "</td><td>" + recievers + "</td><td>" + msg.SentOn + "</td</tr>";
                    recievers = string.Empty;
                }

            }
            return new JavaScriptSerializer().Serialize(html);
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void SendMessagesToUsers(string[] recievers, string title, string message)
        {
            var msgSender = new MessagingBL();
            
                msgSender.SendMessage(Session["username"].ToString(), recievers, title, message);
            
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public  void SignOut()
        {
            Session.Clear();
            
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void AssignUsers(int orderID, string username)
        {
            new AssignmentBL().AssignDesigners(orderID, username, Session["username"].ToString());

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void RejrctOrder(int orderID, string reason)
        {
            new AssignmentBL().ReajectOrder(orderID,reason);

        }

        //public void ChangeStatus
    }
}
