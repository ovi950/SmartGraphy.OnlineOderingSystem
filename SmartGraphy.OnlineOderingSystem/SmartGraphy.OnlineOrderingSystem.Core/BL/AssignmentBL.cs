using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class AssignmentBL : AbstractBL<TB_User, long>
    {
        public List<TB_User> GetAllDesigners()
        {
            var designers = (from d in EntityManager.TB_Users
                             where d.UserType == "designer" && d.Status == "active"
                             select d
                           ).ToList();
            return designers;
        }

        public void AssignDesigners(int orderID, string username, string Supervisor)
        {
            EntityManager.TB_DesignerAssignments.InsertOnSubmit
            (new TB_DesignerAssignment()
            {
                OrderID = orderID,
                AssignedBy = Supervisor,
                AssignedOn = DateTime.Now,
                Designer=username,

            });

            ChangeStatus(orderID,"assigned");
            EntityManager.SubmitChanges();
        }

        
        public void ReajectOrder(int orderID,string reason)
        {
            var order = (from d in EntityManager.TB_OrderHeaders
                         where d.HeaderID == orderID
                         select d
                         ).FirstOrDefault();
            order.Status = "rejected";
            order.ResonForReject = reason;
        }
        public void ChangeStatus(int orderID,string status)
        {
            var order = (from d in EntityManager.TB_OrderHeaders
                         where d.HeaderID == orderID
                         select d
                         ).FirstOrDefault();
            order.Status = status;

            EntityManager.SubmitChanges();
        }
    }
}
