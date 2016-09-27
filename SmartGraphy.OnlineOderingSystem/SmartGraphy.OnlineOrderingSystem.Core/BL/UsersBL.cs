using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGraphy.OnlineOrderingSystem.Core.DTO;
using SmartGraphy.OnlineOrderingSystem.Core.Entities;

namespace SmartGraphy.OnlineOrderingSystem.Core.BL
{
    public class UsersBL : AbstractBL<TB_User, long>
    {
        public int VerifyUser(string userName, string password)
        {
            var userDetails = (from d in EntityManager.TB_Users
                               where d.Username == userName && d.Password == password
                               select d
           ).SingleOrDefault();

            if (userDetails != null && userDetails.Status == "active")
            {
                //var employeeDetails = (from d in EntityManager.TB_Employees
                //                       where d.NIC == UserDertails.NICNo
                //                       select new EmployeeEntity()
                //                       {
                //                           FName = d.FirstName,
                //                           LName = d.LastName,
                //                           AdLine1 = d.AdLine1,
                //                           AdLine2 = d.AdLine2,
                //                           AdLine3 = d.AdLine3,
                //                           ContactNo = d.ContactNo,
                //                           Email = d.Email,
                //                           UserStatus = UserDertails.Status
                //                       }
                //    ).ToList();

                return 1;
            }
            else if (userDetails != null && userDetails.Status == "blocked")
            {
                return 2;
            }
            else if (userDetails != null && userDetails.Status == "new")
            {
                return 3;
            }
            else {
                //var employeeDetails = new EmployeeEntity();
                //employeeDetails.UserStatus = "";
                return 0;

            }
        }
        public bool VerifyUsername(string username)
        {
            var user = (from d in EntityManager.TB_Users
                        where d.Username == username
                        select d).SingleOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return true;
            }

        }
        public List<EmployeeEntity> getAllUsers()
        {
            var allUsers = (from d in EntityManager.TB_Users
                            select new EmployeeEntity()
                            {
                                FName = d.TB_Employee.FirstName,
                                LName = d.TB_Employee.LastName,
                                AdLine1 = d.TB_Employee.AdLine1,
                                AdLine2 = d.TB_Employee.AdLine2,
                                AdLine3 = d.TB_Employee.AdLine3,
                                ContactNo = d.TB_Employee.ContactNo,
                                Email = d.TB_Employee.Email,
                                PhotoPath = d.TB_Employee.ImgPath,
                                NicNo = d.TB_Employee.NIC,
                                Username = d.Username,
                                UserType = d.UserType,
                                Status = d.Status,
                                Password = d.Password
                            }
                          ).ToList();
            return allUsers;
        }
        
        public bool AddNewUser(string nic, string username, string type, string fname, string lname, string adline1, string adline2, string adline3, string contactno, string email, string photo)
        {
            Random rnd = new Random();
            string random = rnd.Next(000, 9999).ToString();
            var newUser = new TB_User();
            newUser.Username = username;
            newUser.Password = "default" + random;
            newUser.UserType = type;
            newUser.Status = "new";

            var newEmployee = new TB_Employee();
            newEmployee.FirstName = fname;
            newEmployee.LastName = lname;
            newEmployee.AdLine1 = adline1;
            newEmployee.AdLine2 = adline2;
            newEmployee.AdLine3 = adline3;
            newEmployee.ContactNo = contactno;
            newEmployee.Email = email;
            EntityManager.TB_Users.InsertOnSubmit(newUser);
            EntityManager.TB_Employees.InsertOnSubmit(newEmployee);
            return SaveChanges();



        }
        public bool UpdateEmployee(string nic, string newNic, string type, string fname, string lname, string adline1, string adline2, string adline3, string contactno, string email)
        {


            try
            {
                var employee = (from d in EntityManager.TB_Employees
                                where d.NIC == nic
                                select d).SingleOrDefault();
                employee.FirstName = fname;
                employee.LastName = lname;
                employee.AdLine1 = adline1;
                employee.AdLine2 = adline2;
                employee.AdLine3 = adline3;
                employee.ContactNo = contactno;
                employee.Email = email;
                employee.NIC = newNic;

                EntityManager.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public bool ChangeUserPassword(string userName, string newUserName, string pw)
        {
            try
            {
                var user = (from d in EntityManager.TB_Users
                            where d.Username == userName
                            select d).SingleOrDefault();
                user.Username = newUserName;
                user.Password = pw;
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool RemoveUser(string userName)
        {
            try
            {
                var user = (from d in EntityManager.TB_Users
                            where d.Username == userName
                            select d).SingleOrDefault();
                user.Status = "blocked";
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ContactAdmin(string title,string content,string user)
        {
            try
            {
                TB_AdminRquest request = new TB_AdminRquest();
                request.RequestTitle = title;
                request.RquestContent = content;
                request.RequestedBy = user;
                request.RequestedOn = DateTime.Now;
                return true;
            }
            catch (Exception)
            {

                return false; 
            }
        }
    }
}
