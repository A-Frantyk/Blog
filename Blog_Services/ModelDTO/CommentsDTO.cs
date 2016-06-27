using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class CommentsDTO
    {
        public int Comment_Number { get; set; }

        public string Comment { get; set; }

        public int? User_Number { get; set; }

        public int? Writes_Number { get; set; }
    }
}
