using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
