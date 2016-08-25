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

        public async Task<Comments> Parse(CommentsDTO commentDtoObj)
        {
            if(commentDtoObj == null)
            {

            }

            if(commentDtoObj.Comment_Number != 0)
            {
                return await ParseForEdit(commentDtoObj);
            }
            else if(commentDtoObj.Comment_Number == 0)
            {
                return ParseForAdd(commentDtoObj);
            }
            else
            {
                throw new NotSupportedException("This operation cannot be supported for this object!!!");
            }
        }
        

        #region Parse for edit and add methods

        private Comments ParseForAdd(CommentsDTO commentDtoObj)
        {
            Comments comment = new Comments()
            {
                Comment = commentDtoObj.Comment,
                User_Number = commentDtoObj.User_Number,
                Writes_Number = commentDtoObj.Writes_Number
            };

            return comment;
        }

        private async Task<Comments> ParseForEdit(CommentsDTO commentDtoObj)
        {
            var item = await _unit.CommentsItemRepository.Get(i => i.Comment_Number == commentDtoObj.Comment_Number);

            Comments comment = item.FirstOrDefault();

            if(comment == null)
            {

            }

            if(comment.Comment != commentDtoObj.Comment)
            {
                comment.Comment = commentDtoObj.Comment;
            }

            if(comment.User_Number != commentDtoObj.User_Number)
            {
                comment.User_Number = commentDtoObj.User_Number;
            }
            
            if(comment.Writes_Number != commentDtoObj.Writes_Number)
            {
                comment.Writes_Number = commentDtoObj.Writes_Number;
            }

            return comment;
        }

        #endregion
    }
}
