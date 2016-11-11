using System;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using SmartGraphy.OnlineOrderingSystem.Core.BL;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Web;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend.Supervisor
{
    public partial class Inbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadUserMessages(1);
                loadDropdowns();
            }
        }

        public void LoadUserMessages(int option)
        {
            new MessagingBL().GetAllSentMessages(Session["username"].ToString());
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
                new MessagingBL().GetAllSentMessages(Session["username"].ToString());
                //string username = Session["username"].ToString();
                //var userMsgs = new MessagingBL().GetAllSentMessages(username);
                //foreach (var msg in userMsgs)
                //{

                //    html += "<tr id=\"" + msg.MsgNo + "\" data-date=\"" + msg.SentOn + "\" data-msg=\"" + msg.MsgContent + "\" data-sender=\"" + msg.SentBy + "\"data-title=\"" + msg.MsgTitle + "\" onClick=\"showSentMessage(this);\"><td> </td><td>" + msg.MsgTitle + "</td><td>" + msg.SentBy + "</td><td>" + msg.SentOn + "</td</tr>";
                //}
                //tbl_msgs.InnerHtml = html;
            }
            tbl_msgs.InnerHtml = html;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        [System.Web.Http.HttpPost]
        public static void sendMessage(string[] reciever, string title, string content, object data)
        {

            new MessagingBL().SendMessage(new Inbox().Session["UserName"].ToString(), reciever, title, content);
            var page = HttpContext.Current.CurrentHandler as Page;
            page.ClientScript.RegisterStartupScript(page.Page.GetType(), "ShowMessage", string.Format("<script stype='text/javascript'>toastr.success('New User added Successfully') </script>"));
        }

        [WebMethod(EnableSession = true)]
        public static void ChangeMsgStatus(string msgNo)
        {
            new MessagingBL().ChangeMessageStatus(int.Parse(msgNo));
        }

        void loadDropdowns()
        {
            ddl_users.DataSource = new SmartGraphy.OnlineOrderingSystem.Core.BL.UsersBL().getAllUsers().Where(x => x.Username != Session["username"].ToString() && x.Status == "active").OrderBy(x => x.FName);
            ddl_users.DataTextField = "FullName";
            ddl_users.DataValueField = "Username";
            ddl_users.DataBind();
        }
    }
}