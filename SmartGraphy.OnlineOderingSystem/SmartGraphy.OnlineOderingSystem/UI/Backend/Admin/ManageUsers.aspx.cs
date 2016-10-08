using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartGraphy.OnlineOrderingSystem.Core.BL;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUserTable();
        }
        private void LoadUserTable()
        {

            int count = 0;
            string html = string.Empty;
            var allusers = new UsersBL().getAllUsers();
            foreach (var user in allusers)
            {
                if (user.UserType != "admin")
                {
                    count++;
                    html += "<tr><td>" + count + "</td>";
                    html += "<td>" + user.Username + "</td>";
                    html += "<td>"+user.FName+"</td>";
                    html += "<td>"+user.LName+"</td>";
                    html += "<td>"+user.ContactNo+"</td>";
                    html += "<td>"+user.ContactNo+"</td>";
                    html += "<td><button  onClick='editUser(this);'  class='btn blue btn-xs' id='" + user.Username+"' data-fname='"+user.FName+"' data-lname='"+user.LName+"' data-nic='"+user.NicNo+"' data-adLine1='"+user.AdLine1+"' data-adLine2='"+user.AdLine2+ "' data-adLine3='"+user.AdLine3+"'data-contactNo='"+user.ContactNo+"'data-email='"+user.Email+"' data-img='"+user.PhotoPath+ "'> <i class='fa-pencil' aria-hidden='true'></i>Edit Details</button></td>";
                    if (user.Status=="blocked")
                    {
                        html += "<td><button onClick='changeStatus(this,0);' class='btn blue btn-xs' id='"+user.Username+ "'><i class='fa fa-unlock' aria-hidden='true'></i>Unblock</button></td>";
                    }
                    else
                    {
                        html += "<td><button onClick='changeStatus(this,1);' class='btn blue btn-xs' id='" + user.Username + "'><i class='fa fa-lock' aria-hidden='true'></i>Block</button></td>";

                    }
                
                    html += "<td><button onClick='resetPassword(this);' class='btn blue btn-xs' id='" + user.Username + "'><i class='fa fa-lock' aria-hidden='true'></i>Reset Password</button></td>";
                    html += "</tr>";
                }
            }
            all_user.InnerHtml = html;

        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {

        }
    }
}