using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual WorkItem Parent { get; set; }
        public virtual ICollection <WorkItem> Children { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public WorkItemStatuses Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public virtual ICollection<WorkItemHistory> History { get; set; }
        public virtual ICollection<Work> LinkedWork { get; set; }
        public virtual ICollection<MessageGroup> Groups { get; set; }
    }
}
