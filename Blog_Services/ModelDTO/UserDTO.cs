using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class UserDTO
    {
        public int User_Number { get; set; }
        
        public string Name { get; set; }
        
        public string Last_Name { get; set; }

        public int? Age { get; set; }
        
        public string Education { get; set; }

        public int? Mobile_Phone { get; set; }
        
        public string Short_Information { get; set; }
        
        public string Facebook_Link { get; set; }

        public string Vk_Link { get; set; }

        public string Mail_Link { get; set; }
    }
}
