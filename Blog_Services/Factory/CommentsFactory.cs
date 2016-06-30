using Blog_Entity.Model;
using Blog_Services.ModelDTO;
using Blog_Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.Factory
{
    public class CommentsFactory : IFactory<CommentsDTO, Comments>
    {
        private readonly IUnitOfWork _unit;

        public CommentsFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public CommentsDTO Create(Comments commentObj)
        {
            if(commentObj == null)
            {

            }

            var commentDTO = new CommentsDTO()
            {
                Comment_Number = commentObj.Comment_Number,
                Comment = commentObj.Comment,
                User_Number = commentObj.User_Number,
                Writes_Number = commentObj.Writes_Number
            };

            return commentDTO;
        }

        public Comments Parse(CommentsDTO commentDtoObj)
        {
            throw new NotImplementedException();
        }
    }
}
