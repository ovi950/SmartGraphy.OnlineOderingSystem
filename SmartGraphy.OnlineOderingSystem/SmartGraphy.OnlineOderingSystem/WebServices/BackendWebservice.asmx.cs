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
        public string VerifyUser(string username, string password)
        {
            UsersBL user = new UsersBL();
            var isVerified = user.VerifyUser(username, password);
            if (isVerified==1)
            {
                Session["username"] = username;
                Session["password"] = password;
            }
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(isVerified);
        }
    }
}
