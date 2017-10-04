using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class MessageGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public virtual WorkItem OwnerItem { get; set; }
        public virtual ICollection<MessageGroupRingSettings> UserSettings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public GroupTypes GroupType { get; set; }
        public virtual ICollection<GroupUser> Users { get; set; }
    }
}
