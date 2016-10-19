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
        public UserEntity VerifyUser(string userName, string password)
        {
            var userDetails = (from d in EntityManager.TB_Users
                               where d.Username == userName && d.Password == password
                               select new UserEntity()
                               {
                                   Username = d.Username,
                                   Password = d.Password,
                                   Status = d.Status,
                                   UserType = d.UserType,
                                   NICNo = d.NICNo
                               }
           ).SingleOrDefault();

            return userDetails;
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
                return false;
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
            var newUser = new TB_User();
            newUser.Username = username;
            newUser.Password = "default";
            newUser.UserType = type;
            newUser.Status = "new";
            newUser.NICNo = nic;

            var newEmployee = new TB_Employee();
            newEmployee.FirstName = fname;
            newEmployee.LastName = lname;
            newEmployee.AdLine1 = adline1;
            newEmployee.AdLine2 = adline2;
            newEmployee.AdLine3 = adline3;
            newEmployee.ContactNo = contactno;
            newEmployee.Email = email;
            newEmployee.NIC = nic;
            newEmployee.ImgPath = photo;
            EntityManager.TB_Users.InsertOnSubmit(newUser);
            // EntityManager.SubmitChanges();
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
                //employee.NIC = newNic;

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
                user.Status = "active";
                EntityManager.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool BlockUser(string userName)
        {
            try
            {
                var user = (from d in EntityManager.TB_Users
                            where d.Username == userName
                            select d).SingleOrDefault();
                user.Status = "blocked";
                EntityManager.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UnblockUser(string userName)
        {
            try
            {
                var user = (from d in EntityManager.TB_Users
                            where d.Username == userName
                            select d).SingleOrDefault();
                user.Status = "active";
                EntityManager.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ContactAdmin(string title, string content, string user)
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
        public EmployeeEntity GetUserDetailsByUsername(string username)
        {
            return (from d in EntityManager.TB_Users
                    where d.Username == username
                    select new EmployeeEntity()
                    {
                        Username = d.Username,
                        UserType = d.UserType,
                        Password = d.UserType,
                        Status = d.Status,
                        FName = d.TB_Employee.FirstName,
                        LName = d.TB_Employee.LastName,
                        NICNo = d.NICNo
                    }).SingleOrDefault();

        }
        public bool ResetPassword(string username)
        {
            if (VerifyUsername(username))
            {
                var results = (from d in EntityManager.TB_Users
                               where d.Username == username
                               select d
                             ).SingleOrDefault();
                results.Password = "default";
                EntityManager.SubmitChanges();

                return true;
            }

            return false;
        }
    }
}
