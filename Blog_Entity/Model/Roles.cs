using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public class Roles
    {
        public Roles()
        {
            User = new HashSet<User>();
        }

        [Key]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public ICollection<User> User { get; set; }
    }
}
