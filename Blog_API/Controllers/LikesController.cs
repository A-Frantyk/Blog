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
using System.Threading.Tasks;
using System.Web.Http;

namespace Blog_API.Controllers
{
    [RoutePrefix("api/like")]
    [AllowAnonymous]
    public class LikesController : BaseController.BaseController<LikesDTO, Likes>
    {
        public LikesController(IUnitOfWork unit, [Named("LikesFCTR")] IFactory<LikesDTO, Likes> likesFactory) : base(unit, likesFactory)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<LikesDTO>> GetLikes()
        {
            IQueryable<Likes> query;

            query = await UnitOfWork.LikesItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result;
        }

        [HttpGet]
        [Route("byWriteId/{writeId}")]
        public async Task<IEnumerable<LikesDTO>> GetLikesByWriteId(int writeId)
        {
            IQueryable<Likes> query;

            query = await UnitOfWork.LikesItemRepository.Get(i => i.Write_Number == writeId);

            var result = query.ToList().Select(a => Factory.Create(a));

            return result;
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> AddLike([FromBody] LikesDTO likes)
        {
            if(likes != null)
            {
                var likeToAdd = await Factory.Parse(likes);

                await UnitOfWork.LikesItemRepository.InsertAsync(likeToAdd);

                return Request.CreateResponse(HttpStatusCode.Created, Factory.Create(likeToAdd));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Cannot add new like!!");
            }
        }
    }
}
