using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class WorkItemHistory
    {
        public long Id { get; set; }
        public virtual WorkItem Parent { get; set; }
        public DateTime ChangeDate { get; set; }
        public virtual User Owner { get; set; }
        public virtual WorkItemFields Field { get; set; }
        public byte[] Data { get; set; }
    }
}
