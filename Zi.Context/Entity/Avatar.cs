using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.Entity
{
    public class Avatar
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public virtual User User { get; set; }
        //[NotMapped]
        public string Image { get; set; } //TODO: возвращать картинку в формате WPF
    }
}
