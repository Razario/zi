using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class WorkItemTypeAssign
    {
        public int Id { get; set; }
        public virtual Role Role { get; set; }
        public WorkItemTypes Type { get; set; }
    }
}
