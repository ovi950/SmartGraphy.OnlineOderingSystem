using SmartGraphy.OnlineOrderingSystem.Core.BL;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class CustomerBL : AbstractBL<TB_Customer, long>
    {
        public TB_Customer SignUP(string FirstName, string LastName, string AddressLine1, string AddressLine2, string AddressLine3, string ContactNo, string Email, string UserName, string Password)
        {
            var customer = new TB_Customer()
            {

                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                AddressLine3 = AddressLine3,
                ContactNo = ContactNo,
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,


            };
            EntityManager.TB_Customers.InsertOnSubmit(customer);

            EntityManager.SubmitChanges();

            return customer;
           
        }

        public bool VeryfiUser(string userName, string password)
        {
            var result = (from d in EntityManager.TB_Customers
                          where d.UserName == userName && d.Password == password
                          select d
                        ).FirstOrDefault();
            if (result != null)
            {
                return true;
            }

            return false;
        }

        public TB_Customer GetCustomerDetailsByUserName(string userName)
        {
            var details = (from d in EntityManager.TB_Customers

                           where d.UserName == userName
                           select d
                         ).FirstOrDefault();
            return details;
        }
        
    }
}
