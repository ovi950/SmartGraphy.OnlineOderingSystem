using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session == null)
            {
                Response.Redirect("error.aspx");
            }
            else
            {
                string html = string.Empty;
                html = "<li><strong><a href=\"Inbox.aspx\"> Messages </a></strong></li> ";
                if (Session["usertype"].ToString() == "admin")
                {

                    html += " <li><strong><a href=\"ManageUsers.aspx\"> Manage Users </a></strong></li>";

                }

                if (Session["usertype"].ToString() == "manager")
                {
                    html += " <li><strong><a href=\"ConfigCategories.aspx\"> Product Categories </a></strong></li>";
                }
                div_menu.InnerHtml = html;
            }
        }
    }
}