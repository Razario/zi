using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class Message
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual User Owner { get; set; }
        public virtual MessageData Data { get; set; }
        public virtual ICollection<MessageUserStatus> Statuses { get; set; }

    }
}
