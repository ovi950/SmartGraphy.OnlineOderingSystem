using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartGraphy.OnlineOrderingSystem.Core.BL;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using System.Web.Services;
using System.Web.Script.Services;

namespace SmartGraphy.OnlineOderingSystem.UI.Backend.Admin
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public partial class ManageUsers : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() != "admin")
                Response.Redirect("../../ErrorProvider/Error.aspx?errorType=unauthorized");
            else
                LoadUserTable();

        }
        private void LoadUserTable()
        {

            int count = 0;
            string html = string.Empty;
            var allusers = new UsersBL().getAllUsers();
            foreach (var user in allusers)
            {
                if (user.Username != Session["username"].ToString())
                {
                    count++;
                    html += "<tr><td>" + count + "</td>";
                    html += "<td>" + user.Username + "</td>";
                    html += "<td>" + user.FName + "</td>";
                    html += "<td>" + user.LName + "</td>";
                    html += "<td>" + user.ContactNo + "</td>";
                    html += "<td>" + user.ContactNo + "</td>";
                    html += "<td><button  onClick='editUser(this);' data-usertype='" + user.UserType + "'  data-toggle = 'modal' href = '#modal_user'  class='btn blue btn-xs' id='" + user.Username + "' data-fname='" + user.FName + "' data-lname='" + user.LName + "' data-nic='" + user.NicNo + "' data-adLine1='" + user.AdLine1 + "' data-adLine2='" + user.AdLine2 + "' data-adLine3='" + user.AdLine3 + "'data-contactNo='" + user.ContactNo + "'data-email='" + user.Email + "' data-img='" + user.PhotoPath + "'> <i class='fa-pencil' aria-hidden='true'></i>Edit Details</button></td>";
                    if (user.Status == "blocked")
                    {
                        html += "<td><button onClick='changeStatus(this,0);' class='btn blue btn-xs' id='" + user.Username + "'><i class='fa fa-unlock' aria-hidden='true'></i>Unblock</button></td>";
                    }
                    else
                    {
                        html += "<td><button onClick='changeStatus(this,1);' class='btn blue btn-xs' id='" + user.Username + "'><i class='fa fa-lock' aria-hidden='true'></i>Block</button></td>";

                    }

                    html += "<td><button onClick='resetPassword(this);' class='btn blue btn-xs' id='" + user.Username + "'>Reset Password</button></td>";
                    html += "</tr>";
                }
            }
            all_user.InnerHtml = html;

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void addNewUsers()
        {


            //new UsersBL().AddNewUser(nic, username, type, fname, lname, adline1, adline2, adline3, cn, mail, photo);
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string nic = txt_nic.Value;
            string username = txt_user.Value;
            string type = ddl_type.Value;
            string fname = txt_fn.Value;
            string lname = txt_ln.Value;
            string adline1 = txt_user.Value;
            string adline2 = txt_ad2.Value;
            string adline3 = txt_ad3.Value;
            string ext = System.IO.Path.GetExtension(this.photo.PostedFile.FileName);
            string newFileName = r.Next(0, 9999).ToString() + this.photo.PostedFile.FileName;
            string cn = txt_cn.Value;
            string mail = txt_email.Value;
            string TargetLocation = Server.MapPath("~/Uploads/UserPhotos");
            if (photo.PostedFile != null && (ext.ToLower().Trim() == ".jpg" || ext.ToLower().Trim() == ".png" || ext.ToLower().Trim() == ".gif" || ext.ToLower().Trim() == ".jpeg"))
            {
                try
                {
                    photo.PostedFile.SaveAs(TargetLocation + "/" + newFileName);
                    var result = new UsersBL().AddNewUser(nic, username, type, fname, lname, adline1, adline2, adline3, cn, mail, TargetLocation + "/" + newFileName);
                    if (result)
                    {
                        LoadUserTable();
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.success('New User added Successfully') </script>"));
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.error('The Username Entered is already exixsts','error') </script>"));
                    }
                }
                catch (Exception ex)
                {

                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.error('" + ex.ToString() + "') </script>"));
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.error('Invalid Photo') </script>"));
            }

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //(string nic, string newNic, string type, string fname, string lname, string adline1, string adline2, string adline3, string contactno, string email)
            var result = new UsersBL().UpdateEmployee(nic.Value, txt_nic.Value, ddl_type.Value, txt_fn.Value, txt_ln.Value, txt_ad1.Value, txt_ad2.Value, txt_ad3.Value, txt_cn.Value, txt_email.Value);
            if (result)
            {
                LoadUserTable();
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.success('Successfully Updated') </script>"));
            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.error('error occured','error') </script>"));

        }
    }
}