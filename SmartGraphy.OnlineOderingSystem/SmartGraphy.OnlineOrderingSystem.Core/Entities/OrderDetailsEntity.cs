using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class OrderDetailsEntity
    {
        public int OrderHeaderID { get; set; }

        public int TemplateID { get; set; }
         public string TemplateName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Qty { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        public  List<OrderRequirements> ItemRequirements { get; set; }
        public OrderDetailsEntity()
        {
            SubTotal = 0;
            ItemRequirements = new List<OrderRequirements>();
        }

    }
}
