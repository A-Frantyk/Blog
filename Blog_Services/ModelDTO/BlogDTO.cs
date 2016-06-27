using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class BlogDTO
    {

        public int Blog_Number { get; set; }
        
        public string Title { get; set; }

        public int Author { get; set; }
        
        public string Description { get; set; }
    }
}
