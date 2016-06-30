using Blog_Entity.Model;
using Blog_Services.Factory;
using Blog_Services.ModelDTO;
using Blog_Services.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog_API.Controllers
{
    public class LikesController : BaseController.BaseController<LikesDTO, Likes>
    {
        public LikesController(IUnitOfWork unit, [Named("LikesFCTR")] IFactory<LikesDTO, Likes> likesFactory) : base(unit, likesFactory)
        {
        }

        [HttpGet]
        public IEnumerable<LikesDTO> GetLikes()
        {
            IQueryable<Likes> query;

            query = UnitOfWork.LikesItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }
    }
}
