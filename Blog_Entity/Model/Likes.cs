using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public class Likes
    {
        [Key]
        public int Like_Number { get; set; }

        public int Like { get; set; }

        public int? Write_Number { get; set; }

        public int? Comment_Number { get; set; }

        public virtual Comments Comments { get; set; }

        public virtual Writes Writes { get; set; }
    }
}
