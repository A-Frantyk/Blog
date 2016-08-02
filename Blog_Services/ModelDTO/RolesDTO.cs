using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class RolesDTO
    {
        public RolesDTO()
        {
            Users = new List<UserDTO>();
        }

        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}
