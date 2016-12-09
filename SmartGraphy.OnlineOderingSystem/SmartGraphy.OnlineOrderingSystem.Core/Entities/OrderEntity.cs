using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class OrderEntity
    {
        public OrderHeaderEntity OrderHeader { get; set; }

        public List<OrderDetailsEntity> OrderDetails { get; set; }

        
    }
}
