using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class OrderRequirements
    {
        public int OrderNo { get; set; }

        public int RequirementNo { get; set; }

        public int ItemNO { get; set; }
        public string RequirementName { get; set; }
        public string Value { get; set; }

        public string DataType { get; set; }



    }
}
