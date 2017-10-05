using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class MessageUserStatus
    {
        public long Id { get; set; }
        public virtual User Owner { get; set; }
        public DateTime ChangeTime { get; set; }
        public MessageStatuses Status { get; set; }
    }
}
