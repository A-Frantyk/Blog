using Blog_Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.ModelDTO
{
    public class WritesDTO
    {
        public WritesDTO()
        {
            Comments = new List<CommentsDTO>();
        }

        public int Write_Number { get; set; }

        public int Topic_Number { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Author { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? Time { get; set; }

        public List<CommentsDTO> Comments { get; set; }

        public UserDTO AuthorFullInfo { get; set; }
    }
}
