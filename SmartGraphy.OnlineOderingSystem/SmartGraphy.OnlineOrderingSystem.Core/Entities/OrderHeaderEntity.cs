using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
   public class OrderHeaderEntity
    {
        public int HeaderID { get; set; }
        public DateTime OrderedDateTime { get; set; }

        public decimal TotalPrice { get; set; }

        public string status { get; set; }

        public DateTime? EndDate { get; set; }

        public String ReasonForReject { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}
