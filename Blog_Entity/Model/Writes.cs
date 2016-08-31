using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public class Writes
    {
        public Writes()
        {
        }

        [Key]
        public int Write_Number { get; set; }
        
        public int Topic_Number { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Author { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? Time { get; set; }

        public virtual Topic Topics { get; set; }
    }
}
