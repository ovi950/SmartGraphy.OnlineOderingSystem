using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class TemplateBL : AbstractBL<TB_ItemTemplateDetail, long>
    {
        public void AddTemplate(string TemplateName, int CategoryID, decimal UnitPrice, string TemplateImage, string CreatedBy)
        {
            EntityManager.TB_ItemTemplateDetails.InsertOnSubmit(new TB_ItemTemplateDetail()
            {
                TemplateName = TemplateName,
                CategoryID = CategoryID,
                //RequiredDays = RequiredDays,
                TemplateImage = TemplateImage,
                UnitPrice = UnitPrice,
                CreatedBy = CreatedBy,
                CreatedOn = DateTime.Now,
                IsEnable = false,


            });

            EntityManager.SubmitChanges();
        }

        public void UpdateTemplate(int TemplateID, string TemplateName, int CategoryID, decimal UnitPrice, string TemplateImage)
        {
            var template = (from d in EntityManager.TB_ItemTemplateDetails
                            where d.ItemNo == TemplateID
                            select d).SingleOrDefault();

            template.CategoryID = CategoryID;
            //template.RequiredDays = RequiredDays;
            template.TemplateImage = TemplateImage;
            template.UnitPrice = UnitPrice;
            template.LastUpdatedOn = DateTime.Now;

            EntityManager.SubmitChanges();
        }

        public List<TB_ItemTemplateDetail> GetAllTemplates()
        {
            var allTemplates = (from d in EntityManager.TB_ItemTemplateDetails select d).ToList();
            return allTemplates;
        }

        public void SetRequirements(object[] requirementID, int templateID)
        {
            var oldRequirements = (from d in EntityManager.TB_ItemRequirements
                                   where d.TemplateID == templateID
                                   select d).ToList();
            EntityManager.TB_ItemRequirements.DeleteAllOnSubmit(oldRequirements);

            foreach (var item in requirementID)
            {
                EntityManager.TB_ItemRequirements.InsertOnSubmit(new TB_ItemRequirement() { RequirementNo = int.Parse(item.ToString()), TemplateID = templateID });
            }
            EntityManager.SubmitChanges();
        }
    }
}
