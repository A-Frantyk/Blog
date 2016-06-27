using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class LikesDTO
    {
        public int Like_Number { get; set; }

        public int Like { get; set; }

        public int? Write_Number { get; set; }

        public int? Comment_Number { get; set; }
    }
}
