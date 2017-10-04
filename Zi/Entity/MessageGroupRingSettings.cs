using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class MessageGroupRingSettings
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual MessageGroup Group { get; set; }
        public bool IsSoundEnabled { get; set; }
        public bool IsBallonEnabled { get; set; }
    }
}
