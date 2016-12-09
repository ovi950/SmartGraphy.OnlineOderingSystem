using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class ShoppingCartHeader
    {
        public int HeaderID { get; set; }
        public DateTime OrderedDateTime { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerNo { get; set; }

        public ShoppingCartHeader()
        {
            TotalPrice = 0;
        }
    }
}
