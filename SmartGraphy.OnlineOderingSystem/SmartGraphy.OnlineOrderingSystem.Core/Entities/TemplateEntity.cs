using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class TemplateEntity
    {
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public int CategoryID { get; set; }
        public int RequiredDays { get; set; }
        public double UnitPrice { get; set; }
        public string TemplateImage { get; set; }
        
    }
}
