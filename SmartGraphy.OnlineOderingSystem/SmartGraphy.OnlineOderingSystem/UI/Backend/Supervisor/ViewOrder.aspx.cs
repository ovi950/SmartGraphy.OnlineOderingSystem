using SmartGraphy.OnlineOrderingSystem.Core.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend.Supervisor
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadOrder();
            if (!Page.IsPostBack)
            {
                headerID.Value = Request.QueryString["id"];
                orderStatus.Value = Request.QueryString["status"];
                //user.Value = Session["username"].ToString();
            }
            SetDesigners();
        }

        void SetDesigners()
        {
            var allUsers = new AssignmentBL().GetAllDesigners();
            var html = new StringBuilder();
            foreach (var user in allUsers)
            {
                html.Append(string.Format($"<tr><td>{user.TB_Employee.FirstName} {user.TB_Employee.LastName}</td><td><a class=\"btn btn-default\" onclick=\"assignUser(this);\" id=\"{user.Username}\" href=\"#\">Assign</a></td></tr>"));
            }
            tbl_designers.InnerHtml = html.ToString();
        }
        void LoadOrder()
        {
            var order = new OrderBL().GetOrderByHeaderID(int.Parse(Request.QueryString["id"].ToString()));
            var orderHeader = order.OrderHeader;
            var orderDetails = order.OrderDetails;
            var html = string.Empty;

            lblAd1.InnerText = orderHeader.Customer.AddressLine1;
            lblAd2.InnerText = orderHeader.Customer.AddressLine2;
            lblAd3.InnerText = orderHeader.Customer.AddressLine3;
            lblCountItems.InnerText = orderDetails.Count.ToString();
            LblCustomerName.InnerText = orderHeader.Customer.FirstName + " " + orderHeader.Customer.LastName;
            lblEndDate.InnerText = orderHeader.EndDate.GetValueOrDefault().ToShortDateString();
            lblOrderDate.InnerText = orderHeader.OrderedDateTime.ToShortDateString();
            lblStatus.InnerText = orderHeader.status;
            foreach (var item in orderDetails)
            {
                html += " <div class=\"row\">";
                html += "<div class=\"col-md-1\"></div>";
                html += "<div class=\"col-md-2\">";
                html += "<label class=\"form-actions\">Category Name:</label>";
                html += " </div>";
                html += "<div class=\"col-md-5\">";
                html += " <label class=\"form-actions\" id=\"lblCountItems\">" + item.CategoryName + "</label>";
                html += " </div >";
                html += " <div class=\"col-md-4\">";
                html += " </div>";
                html += "</div>";

                html += " <div class=\"row\">";
                html += "<div class=\"col-md-1\"></div>";
                html += "<div class=\"col-md-2\">";
                html += "<label class=\"form-actions\">Template Name:</label>";
                html += " </div>";
                html += "<div class=\"col-md-5\">";
                html += " <label class=\"form-actions\" id=\"lblCountItems\">" + item.TemplateName + "</label>";
                html += " </div>";
                html += " <div class=\"col-md-4\">";
                html += " </div>";
                html += "</div>";
                html += "<br>";
                html += " <div class=\"row\">";
                html += "<div class=\"col-md-1\"></div>";
                html += "<div class=\"col-md-2\">";
                html += "<label class=\"form-actions\"><strong>Requirements<strong></label>";
                html += "<br><hr style=\"border-width: 3px; border-color: #939898;\">";
                html += " </div>";



                html += "</div>";

                foreach (var requirement in item.ItemRequirements)
                {
                    if (requirement.DataType == "file")
                    {
                        html += " <div class=\"row\">";
                        html += "<div class=\"col-md-1\"></div>";
                        html += "<div class=\"col-md-2\">";
                        html += "<label class=\"form-actions\">" + requirement.RequirementName + "</label>";
                        html += " </div>";
                        html += "<div class=\"col-md-9\">";
                        html += "<img class=\"img img-responsive\" src=\"~" + requirement.Value + "\">";
                        html += "</div>";
                        html += "</div>";
                    }

                    else
                    {
                        html += " <div class=\"row\">";
                        html += "<div class=\"col-md-1\"></div>";
                        html += "<div class=\"col-md-2\">";
                        html += "<label class=\"form-actions\">" + requirement.RequirementName + "</label>";
                        html += " </div>";
                        html += "<div class=\"col-md-5\">";
                        html += " <label class=\"form-actions\" id=\"lblCountItems\">" + requirement.Value + "</label>";
                        html += " </div>";
                        html += " <div class=\"col-md-4\">";
                        html += " </div>";
                        html += "</div>";
                    }
                }
                html += "<div class=\"row\">";
                html += "<hr style=\"border-width: 3px; border-color: #939898;\">";
                html += "</div>";
            }

            orderBody.InnerHtml = html;

        }


    }
}