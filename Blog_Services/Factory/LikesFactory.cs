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
    public enum LikesPurpose
    {
        ForComment = 1,
        ForWrites = 2
    };

    public class LikesFactory : IFactory<LikesDTO, Likes>
    {
        private readonly IUnitOfWork _unit;

        public LikesFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public LikesDTO Create(Likes likesObj)
        {
            if(likesObj == null)
            {

            }

            var likesDTO = new LikesDTO()
            {
                Like_Number = likesObj.Like_Number,
                Like = likesObj.Like,
                Write_Number = likesObj.Write_Number,
                Comment_Number = likesObj.Comment_Number
            };

            return likesDTO;
        }

        public Likes Parse(LikesDTO likesDtoObj)
        {
            if(likesDtoObj == null)
            {

            }

            return ParseForEdit(likesDtoObj);
        }

        #region Parse for add and edit methods

        public Likes ParseForAdd(LikesPurpose likePurpose)
        {
            Likes like = new Likes()
            {
                Like = 0
            };

            if(likePurpose == LikesPurpose.ForComment)
            {
                like.Comment_Number = Int32.Parse(likePurpose.ToString());
                like.Write_Number = null;
            }
            else if(likePurpose == LikesPurpose.ForWrites)
            {
                like.Write_Number = Int32.Parse(likePurpose.ToString());
                like.Comment_Number = null;
            }
            else
            {
                throw new NotSupportedException("Cannot create and add new like because of input parameter of this method.");
            }

            return like;
        }
        

        private Likes ParseForEdit(LikesDTO likesDtoObj)
        {
            Likes like = _unit.LikesItemRepository.Get(i => i.Like_Number == likesDtoObj.Like_Number)
                                                  .FirstOrDefault();

            if(like == null)
            {

            }

            if(like.Like != likesDtoObj.Like)
            {
                like.Like = likesDtoObj.Like;
            }
            
            if(like.Write_Number != likesDtoObj.Write_Number)
            {
                like.Write_Number = likesDtoObj.Write_Number;
            }

            if(like.Comment_Number != likesDtoObj.Comment_Number)
            {
                like.Comment_Number = likesDtoObj.Comment_Number;
            }

            return like;
        }

        #endregion
    }
}
