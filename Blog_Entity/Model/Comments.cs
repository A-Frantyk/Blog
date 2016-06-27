using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity.Model
{
    public class Comments
    {
        public Comments()
        {
            Likes = new HashSet<Likes>();
        }

        [Key]
        public int Comment_Number { get; set; }

        public string Comment { get; set; }

        public int? User_Number { get; set; }

        public int? Writes_Number { get; set; }

        public ICollection<Likes> Likes { get; set; }
    }
}
