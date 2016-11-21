using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
   public class EmployeeEntity:UserEntity
    {
        public string FullName { get; set; }
        public string NicNo { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string AdLine1 { get; set; }
        public string AdLine2 { get; set; }
        public string AdLine3 { get; set; }

        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
       

    }
}
