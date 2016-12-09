using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;


namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class CategoryBL : AbstractBL<TB_ItemCategory, long>
    {
        public List<ItemCategoryEntity> GetAllCategories()
        {
            var allCategories = (from d in EntityManager.TB_ItemCategories
                                 select new ItemCategoryEntity()
                                 {
                                     CategoryID = d.CategoryID,
                                     CategoryName = d.CategoryName,
                                     CategoryImg = d.CategoryImage
                                 }).ToList();
            return allCategories;
        }

        public List<ItemCategoryEntity> GetAllAvailableCategories()
        {
            var allCategories = (from d in EntityManager.TB_ItemCategories
                                 where d.IsEnabled == true
                                 select new ItemCategoryEntity()
                                 {
                                     CategoryID = d.CategoryID,
                                     CategoryName = d.CategoryName,
                                     CategoryImg = d.CategoryImage,
                                     IsEnable = d.IsEnabled.GetValueOrDefault()
                                 }).ToList();
            return allCategories;
        }

        public void AddNewCategory( string categoryName, string categoryImg, string userName)
        {
            EntityManager.TB_ItemCategories.InsertOnSubmit
                (new TB_ItemCategory()
                {

                    CategoryName = categoryName,
                    CategoryImage = categoryImg,
                    IsEnabled = true,
                    CreatedBy = userName,
                    CreatedOn=(DateTime?)DateTime.Today,
                    LastUpdatedBy=userName,
                    LastUpdatedOn= (DateTime?)DateTime.Today


                });
            EntityManager.SubmitChanges();
        }

        public void UpdateCategory(int categoryID, string categoryName, string categoryImg,string username)
        {
            var category = (from d in EntityManager.TB_ItemCategories
                            where d.CategoryID == categoryID
                            select d).SingleOrDefault();
            category.CategoryName = categoryName;
            category.CategoryImage = categoryImg;
            category.IsEnabled = true;
            category.LastUpdatedOn = DateTime.Today;
            category.LastUpdatedBy = username;
            //EntityManager.TB_ItemCategories.InsertOnSubmit(category);
            EntityManager.SubmitChanges();
        }
        
        public  void EnableOrDissableCategory(int categoryID)
        {
            var category = (from d in EntityManager.TB_ItemCategories
                            where d.CategoryID == categoryID
                            select d).SingleOrDefault();
            category.IsEnabled = !category.IsEnabled;
        }
    }
}
