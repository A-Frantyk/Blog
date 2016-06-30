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
            throw new NotImplementedException();
        }
    }
}
