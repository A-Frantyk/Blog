using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public class Topic
    {
        [Key]
        public int Topic_Number { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public string Topic_Title { get; set; }
        
        public int Blog_Number { get; set; }

        public ICollection<Writes> Writes { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
