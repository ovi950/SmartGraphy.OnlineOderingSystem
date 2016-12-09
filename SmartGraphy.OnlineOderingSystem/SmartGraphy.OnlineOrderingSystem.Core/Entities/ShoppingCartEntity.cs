using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public static class ShoppingCartEntity
    {
        public static ShoppingCartHeader header = new ShoppingCartHeader();

        public static List<OrderDetailsEntity> addedItems = new List<OrderDetailsEntity>();
        
        
    }
}
