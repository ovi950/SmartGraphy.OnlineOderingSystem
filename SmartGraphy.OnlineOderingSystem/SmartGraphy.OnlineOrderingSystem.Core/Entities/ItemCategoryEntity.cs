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

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public List<TemplateEntity> Templates { get; set; }
    }
}
