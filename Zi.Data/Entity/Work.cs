using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class Work
    {
        public long Id { get; set; }
        public DateTime EventTime { get; set; }
        public WorkReason Reason { get; set; }
        public string Comment { get; set; }
        public virtual User Owner { get; set; }
        public virtual WorkItem Item { get; set; }
    }
}
