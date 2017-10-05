using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class MessageData
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public virtual Attachment Attachment { get; set; }
        public virtual Message Parent { get; set; }
    }
}
