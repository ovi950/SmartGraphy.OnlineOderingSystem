using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGraphy.OnlineOrderingSystem.Core.Entities
{
    public class RequirementEntity
    {
        public int RequirementID { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }

        public string ControllerID { get; set; }
    }
}
