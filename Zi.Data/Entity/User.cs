using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zi.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public virtual Role Role{ get; set; }
        public virtual Avatar ImageMin { get; set; }
        public virtual Avatar ImageFull { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Work> Work { get; set; }

    }
}
