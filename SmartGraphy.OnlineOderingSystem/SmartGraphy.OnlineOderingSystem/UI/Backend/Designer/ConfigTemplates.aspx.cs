using SmartGraphy.OnlineOrderingSystem.Core.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartGraphy.OnlineOderingSystem.UI.Customer
{
    public partial class ConfigTemplates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadTemplates();
                ddlCat.DataSource = new CategoryBL().GetAllAvailableCategories();
                ddlCat.DataTextField = "CategoryName";
                ddlCat.DataValueField = "CategoryID";
                ddlCat.DataBind();

                ddlRequirements.DataSource = new RequirementBL().GetAllRequirements().Where(x=>x.ReqNo!=13|| x.ReqNo != 14);
                ddlRequirements.DataTextField = "Description";
                ddlRequirements.DataValueField = "ReqNo";
                ddlRequirements.DataBind(); 
            }

        }

        void LoadTemplates()
        {
           
            StringBuilder html = new StringBuilder();
            var allTemplates = new TemplateBL().GetAllTemplates();
            foreach (var template in allTemplates)
            {
                //if (template.CreatedBy != Session["username"].ToString()) {
                //    continue;
                //}
                List<int> x=new List<int>();
                
                var requirements = new RequirementBL().GetAllRequirementsByTemplateID(template.ItemNo);
                foreach (var item in requirements)
                {
                   x.Add(item.ReqNo);
                }
                
                html.Append(string.Format($"<tr><td>{template.TemplateName}</td><td>{template.IsEnable}</td><td>{template.CreatedOn}</td><td>{template.LastUpdatedOn}</td> <td> <button id=\"{template.ItemNo}\" type=\"button\" class=\"btn blue\" data-name=\"{template.TemplateName}\" data-requirements=\"{new JavaScriptSerializer().Serialize(x)}\" data-image=\"{template.TemplateImage}\" onClick=\"setRequirements(this);\" >Set Requirements</button></td> <td><button id=\"{template.ItemNo}\" type=\"button\" class=\"btn blue\" data-name=\"{template.TemplateName}\" data-cat=\"{template.CategoryID}\"  data-price=\"{template.UnitPrice}\" data-image=\"{template.TemplateImage}\" onClick=\"editTemplate(this);\" > Edit</button> </tr>"));
            }
            tbl_cat.InnerHtml = html.ToString();
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            var ext = System.IO.Path.GetExtension(file_Template.PostedFile.FileName);
            var targetLocation = Server.MapPath("~/Uploads/Templates");
            try
            {
                file_Template.PostedFile.SaveAs(string.Format($"{targetLocation}/{txt_temName.Value}_{file_Template.PostedFile.FileName}"));
                new TemplateBL().UpdateTemplate(int.Parse(hdnID.Value), txt_temName.Value, int.Parse(ddlCat.Value), Convert.ToDecimal(txtPrice.Value), string.Format($"/Uploads/Templates/{txt_temName.Value}_{file_Template.PostedFile.FileName}"));
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.success('Successfully Updated') </script>"));
                LoadTemplates();
            }
            catch (Exception ex)
            {

            }
        }



        protected void btnAddCat_Click(object sender, EventArgs e)
        {
            var ext = System.IO.Path.GetExtension(file_Template.PostedFile.FileName);
            var targetLocation = Server.MapPath("~/Uploads/Templates");
            if (file_Template.PostedFile != null && (ext.ToLower().Trim() == ".jpg" || ext.ToLower().Trim() == ".png" || ext.ToLower().Trim() == ".gif" || ext.ToLower().Trim() == ".jpeg"))
            {
                try
                {
                    file_Template.PostedFile.SaveAs(string.Format($"{targetLocation}/{txt_temName.Value}_{file_Template.PostedFile.FileName}"));
                    new TemplateBL().AddTemplate(txt_temName.Value, int.Parse(ddlCat.Value), int.Parse(txtPrice.Value), string.Format($"/Uploads/Templates/{txt_temName.Value}_{file_Template.PostedFile.FileName}"), Session["username"].ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "ShowMessage", string.Format("<script type='text/javascript'>toastr.success('New Category Added Successfully') </script>"));
                    LoadTemplates();
                }
                catch (Exception ex)
                {

                }
            }

        }

        protected void btnSetRequirements_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void setRiqurements(object[] requirement, int templateID)
        {

            var soure = new TemplateBL();



            soure.SetRequirements(requirement, templateID);

        }

        [WebMethod]
        public static string getRiqurements( int templateID)
        {
            var requirements = new RequirementBL().GetAllRequirementsByTemplateID(templateID);

            return new JavaScriptSerializer().Serialize(requirements);
        }
    }
}