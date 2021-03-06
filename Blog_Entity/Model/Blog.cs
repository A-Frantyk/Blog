﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public class Blog 
    {
        public Blog()
        {
            Topics = new HashSet<Topic>();
        }

        [Key]
        public int Blog_Number { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }

        public int Author { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
