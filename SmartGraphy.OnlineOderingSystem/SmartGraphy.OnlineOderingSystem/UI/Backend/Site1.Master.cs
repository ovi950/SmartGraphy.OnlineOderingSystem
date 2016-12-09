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
            if (Session["usertype"] == null)
            {
                Response.Redirect(ResolveUrl("~/UI/Backend/Login.aspx"));
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
                    html += " <li><strong><a href=\"ViewOrders.aspx\"> View All Orders </a></strong></li>";
                }

                if (Session["usertype"].ToString() == "designer")
                {
                    html += " <li><strong><a href=\"ConfigTemplates.aspx\"> Product Templates </a></strong></li>";
                    html += " <li><strong><a href=\"TemplateRequirements.aspx\">  Template Requirements </a></strong></li>";
                    html += " <li><strong><a href=\"ViewOrders.aspx\"> View Assigned Orders </a></strong></li>";
                }
                div_menu.InnerHtml = html;
            }
        }
    }
}