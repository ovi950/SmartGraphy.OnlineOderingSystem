using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;
using System.Data.Linq;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class OrderBL : AbstractBL<TB_OrderRequirement, long>
    {
        public TB_OrderHeader AddNewOrder()
        {
            EntitySet<TB_OrderDetail> orderDetails = new EntitySet<TB_OrderDetail>();

            var orderRequirements = new EntitySet<TB_OrderRequirement>();
            var c = 0;
            foreach (var item in ShoppingCartEntity.addedItems)
            {

                orderDetails.Add(new TB_OrderDetail()
                {
                    ItemID = item.TemplateID,

                    Qty = item.Qty,
                    SubTotal = item.SubTotal

                });

                foreach (var item1 in item.ItemRequirements)
                {


                    orderDetails[c].TB_OrderRequirements.Add(new TB_OrderRequirement()
                    {
                        ItemNO = item1.ItemNO,
                        RequirementNo = item1.RequirementNo,
                        Value = item1.Value
                    });

                }

                c++;
            }


            var orderHeader = new TB_OrderHeader()
            {
                CustomerNo = ShoppingCartEntity.header.CustomerNo,
                OrderedDateTime = DateTime.Now,
                Status="new",
                TotalPrice = ShoppingCartEntity.header.TotalPrice,
                TB_OrderDetails = orderDetails,

            };

            EntityManager.TB_OrderHeaders.InsertOnSubmit(orderHeader);
            //EntityManager.TB_OrderRequirements.InsertAllOnSubmit(orderRequirements);
            EntityManager.SubmitChanges();
            return orderHeader;


        }
      public  OrderEntity GetOrderByHeaderID(int headerID)
        {
            var order = (from d in EntityManager.TB_OrderHeaders
                         where d.HeaderID == headerID
                         select new OrderEntity()
                         {
                             OrderHeader = new OrderHeaderEntity()
                             {
                                 Customer = new CustomerEntity()
                                 {

                                     AddressLine1 = d.TB_Customer.AddressLine1,
                                     AddressLine2 = d.TB_Customer.AddressLine2,
                                     AddressLine3 = d.TB_Customer.AddressLine3,
                                     ContactNo = d.TB_Customer.ContactNo,
                                     CustomerNo = d.TB_Customer.CustomerNo,
                                     Email = d.TB_Customer.Email,
                                     FirstName = d.TB_Customer.FirstName,
                                     LastName = d.TB_Customer.LastName,

                                 },
                                 EndDate = d.EndDate,
                                 HeaderID = d.HeaderID,
                                 OrderedDateTime = d.OrderedDateTime,
                                 status = d.Status,
                                 TotalPrice = d.TotalPrice,
                                 ReasonForReject = d.ResonForReject
                             },
                             OrderDetails = (from x in d.TB_OrderDetails
                                             where x.OrderID == headerID
                                             select new OrderDetailsEntity()
                                             {

                                                 CategoryName = x.TB_ItemTemplateDetail.TB_ItemCategory.CategoryName,
                                                 TemplateName = x.TB_ItemTemplateDetail.TemplateName,
                                                 OrderHeaderID = x.ItemID,
                                                 Qty = x.Qty,
                                                 SubTotal = x.SubTotal,
                                                 UnitPrice = x.TB_ItemTemplateDetail.UnitPrice,
                                                 ItemRequirements = (from r in x.TB_OrderRequirements

                                                                     select new OrderRequirements()
                                                                     {
                                                                         DataType = r.TB_Requirement.DataType,
                                                                         RequirementName = r.TB_Requirement.Description,
                                                                         Value = r.Value


                                                                     }).ToList()
                                             }
                                            ).ToList()


                         }
                       ).FirstOrDefault();
            return order;

        }

        public List<OrderEntity> GetAllOrders( )
        {
            var order = (from d in EntityManager.TB_OrderHeaders
                         
                         select new OrderEntity()
                         {
                             OrderHeader = new OrderHeaderEntity()
                             {
                                 Customer = new CustomerEntity()
                                 {

                                     AddressLine1 = d.TB_Customer.AddressLine1,
                                     AddressLine2 = d.TB_Customer.AddressLine2,
                                     AddressLine3 = d.TB_Customer.AddressLine3,
                                     ContactNo = d.TB_Customer.ContactNo,
                                     CustomerNo = d.TB_Customer.CustomerNo,
                                     Email = d.TB_Customer.Email,
                                     FirstName = d.TB_Customer.FirstName,
                                     LastName = d.TB_Customer.LastName,

                                 },
                                 EndDate = d.EndDate,
                                 HeaderID = d.HeaderID,
                                 OrderedDateTime = d.OrderedDateTime,
                                 status = d.Status,
                                 TotalPrice = d.TotalPrice,
                                 ReasonForReject = d.ResonForReject
                             },
                             OrderDetails = (from x in d.TB_OrderDetails
                                            
                                             select new OrderDetailsEntity()
                                             {

                                                 CategoryName = x.TB_ItemTemplateDetail.TB_ItemCategory.CategoryName,
                                                 TemplateName = x.TB_ItemTemplateDetail.TemplateName,
                                                 OrderHeaderID = x.ItemID,
                                                 Qty = x.Qty,
                                                 SubTotal = x.SubTotal,
                                                 UnitPrice = x.TB_ItemTemplateDetail.UnitPrice,
                                                 ItemRequirements = (from r in x.TB_OrderRequirements

                                                                     select new OrderRequirements()
                                                                     {
                                                                         DataType = r.TB_Requirement.DataType,
                                                                         RequirementName = r.TB_Requirement.Description,
                                                                         Value = r.Value


                                                                     }).ToList()
                                             }
                                            ).ToList()


                         }
                       ).ToList();
            return order;

        }

        public List<OrderEntity> GetAllOrders(string username)
        {
            var order = (from d in EntityManager.TB_OrderHeaders
                         where d.TB_DesignerAssignments.Any<TB_DesignerAssignment>(x=> x.TB_User1.Username==username)
                         select new OrderEntity()
                         {
                             OrderHeader = new OrderHeaderEntity()
                             {
                                 Customer = new CustomerEntity()
                                 {

                                     AddressLine1 = d.TB_Customer.AddressLine1,
                                     AddressLine2 = d.TB_Customer.AddressLine2,
                                     AddressLine3 = d.TB_Customer.AddressLine3,
                                     ContactNo = d.TB_Customer.ContactNo,
                                     CustomerNo = d.TB_Customer.CustomerNo,
                                     Email = d.TB_Customer.Email,
                                     FirstName = d.TB_Customer.FirstName,
                                     LastName = d.TB_Customer.LastName,

                                 },
                                 EndDate = d.EndDate,
                                 HeaderID = d.HeaderID,
                                 OrderedDateTime = d.OrderedDateTime,
                                 status = d.Status,
                                 TotalPrice = d.TotalPrice,
                                 ReasonForReject = d.ResonForReject
                             },
                             OrderDetails = (from x in d.TB_OrderDetails

                                             select new OrderDetailsEntity()
                                             {

                                                 CategoryName = x.TB_ItemTemplateDetail.TB_ItemCategory.CategoryName,
                                                 TemplateName = x.TB_ItemTemplateDetail.TemplateName,
                                                 OrderHeaderID = x.ItemID,
                                                 Qty = x.Qty,
                                                 SubTotal = x.SubTotal,
                                                 UnitPrice = x.TB_ItemTemplateDetail.UnitPrice,
                                                 ItemRequirements = (from r in x.TB_OrderRequirements

                                                                     select new OrderRequirements()
                                                                     {
                                                                         DataType = r.TB_Requirement.DataType,
                                                                         RequirementName = r.TB_Requirement.Description,
                                                                         Value = r.Value


                                                                     }).ToList()
                                             }
                                            ).ToList()


                         }
                       ).ToList();
            return order;

        }


    }
}
