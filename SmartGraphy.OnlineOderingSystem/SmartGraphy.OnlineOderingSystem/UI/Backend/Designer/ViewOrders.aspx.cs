using SmartGraphy.OnlineOrderingSystem.Core.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend.Designer
{
    public partial class ViewOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var html = new StringBuilder();
            var allOrders = new OrderBL().GetAllOrders(Session["username"].ToString());
            foreach (var order in allOrders)
            {
                html.Append(string.Format($"<tr><td>{order.OrderHeader.Customer.FirstName} {order.OrderHeader.Customer.LastName}</td><td>{order.OrderHeader.Customer.ContactNo}</td><td>{order.OrderHeader.OrderedDateTime}</td><td>{order.OrderHeader.status}</td><td><a class=\"btn btn-default\" href=ViewOrder.aspx?id={order.OrderHeader.HeaderID}>view order</a></td></tr>"));
            }

            tbl_order.InnerHtml = html.ToString();
        }
    }
}