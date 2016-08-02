using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class TopicDTO
    {
        public TopicDTO()
        {
            Writes = new List<WritesDTO>();
        }

        public int Topic_Number { get; set; }
        
        public string Description { get; set; }

        public string Topic_Title { get; set; }

        public int Blog_Number { get; set; }

        public List<WritesDTO> Writes { get; set; }
    }
}
