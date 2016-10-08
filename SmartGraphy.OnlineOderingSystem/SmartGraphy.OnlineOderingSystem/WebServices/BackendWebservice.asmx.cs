using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using SmartGraphy.OnlineOrderingSystem.Core.BL;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;


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
        public List<UserEntity> VerifyUser(string username, string password)
        {
            var userDetails = new UsersBL().VerifyUser(username, password);
            if (userDetails != null)
            {
                Session["username"] = username;
                Session["password"] = password;

            }
            return userDetails;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public bool AddNewUser(string nic, string username, string type, string fname, string lname, string adline1, string adline2, string adline3, string contactno, string email, string photo)
        {

            return new UsersBL().AddNewUser(nic, username, type, fname,lname,adline1,adline2,adline3,contactno,email,photo);
        }

    }
}
