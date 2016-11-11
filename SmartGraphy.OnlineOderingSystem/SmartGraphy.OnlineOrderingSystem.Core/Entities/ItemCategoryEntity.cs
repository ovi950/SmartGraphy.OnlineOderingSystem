using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class ItemCategoryEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImg { get; set; }
        public bool IsEnable { get; set; }
    }
}
