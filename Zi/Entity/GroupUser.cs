using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class GroupUser
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public DateTime GroupInDate { get; set; }
        public DateTime GroupOutDate { get; set; }

    }
}
