using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class ItemCategoryBL : AbstractBL<TB_ItemCategory, long>
    {
        public List<ItemCategoryEntity> GetAllItemCategories()
        {
            var allCategories = (from d in EntityManager.TB_ItemCategories
                                 select new ItemCategoryEntity()
                                 {
                                     CreatedBy=d.CreatedBy,
                                     CreatedOn=d.CreatedOn,
                                     LastUpdatedBy=d.LastUpdatedBy,
                                     LastUpdatedOn=d.LastUpdatedOn,
                                     CategoryID = d.CategoryID,
                                     CategoryName = d.CategoryName,
                                     CategoryImg = d.CategoryImage,
                                     IsEnable = d.IsEnabled.GetValueOrDefault(),
                                     Templates = (from t in d.TB_ItemTemplateDetails
                                                  where t.CategoryID == d.CategoryID
                                                  select new TemplateEntity()

                                                  {
                                                      CategoryID = t.CategoryID,
                                                     // RequiredDays = t.RequiredDays,
                                                      TemplateID = t.ItemNo,
                                                      TemplateImage = t.TemplateImage,
                                                      TemplateName = t.TemplateName,
                                                      UnitPrice = Convert.ToDouble(t.UnitPrice),
                                                      Requirements = (from x in t.TB_ItemRequirements
                                                                      select new RequirementEntity()
                                                                      {
                                                                          ControllerID=x.TB_Requirement.ControllerID,
                                                                          DataType= x.TB_Requirement.DataType,
                                                                          Description= x.TB_Requirement.Description,
                                                                          RequirementID= x.TB_Requirement.ReqNo

                                                                      }
                                                                    ).ToList(),
                                                  }).ToList()
                                        
                                 }


                               ).ToList();
            return allCategories;
        }
    }
}
