using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using SmartGraphy.OnlineOrderingSystem.Core.BL;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend.Admin
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public partial class Inbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUserMessages(Session["username"].ToString());
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void LoadUserMessages(string username)
        {
            string status = string.Empty;
            string html = string.Empty;
            var userMsgs = new MessagingBL().AllMessages(username);
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
            tbl_msgs.InnerHtml = html;
        }
    }
}