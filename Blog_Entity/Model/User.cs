﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Roles>();
        }

        [Key]
        public int User_Number { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Last_Name { get; set; }

        public int? Age { get; set; }

        [MaxLength(256)]
        public string Education { get; set; }

        public int? Mobile_Phone { get; set; }

        [MaxLength(2048)]
        public string Short_Information { get; set; }

        
        public string Facebook_Link { get; set; }

        public string Vk_Link { get; set; }

        public string Mail_Link { get; set; }
        
        public UserCredentials UserCredentials { get; set; }

        public ICollection<Roles> Roles { get; set; }
    }
}
