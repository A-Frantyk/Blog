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
    public class CommentsController : BaseController.BaseController<CommentsDTO, Comments>
    {
        public CommentsController(IUnitOfWork unit, [Named("CommentsFCTR")] IFactory<CommentsDTO, Comments> commentFactory) : base(unit, commentFactory)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<CommentsDTO>> GetComments()
        {
            IQueryable<Comments> query;

            query = await UnitOfWork.CommentsItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }

        [HttpGet]
        [Route("api/comments/{commentID}")]
        public async Task<HttpResponseMessage> GetCommentByID(int commentID)
        {
            var comment = await UnitOfWork.CommentsItemRepository.GetByIdAsync(commentID);

            if(comment != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(comment));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Comment not found!!");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<CommentsDTO>> GetCommentsByWriteID(int writeID)
        {
            var comment = await UnitOfWork.CommentsItemRepository.Get(i => i.Writes_Number == writeID);

            var result = comment.ToList().Select(a => Factory.Create(a));

            return result;
        }

        [HttpPut]
        public async Task<HttpResponseMessage> EditComment([FromBody] CommentsDTO comment)
        {
            var commentToEdit = await Factory.Parse(comment);

            if(commentToEdit != null)
            {
                UnitOfWork.CommentsItemRepository.Update(commentToEdit);

                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(commentToEdit));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, "Cannot modify comment!!");
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddComment([FromBody] CommentsDTO comment)
        {
            var commentToAdd = await Factory.Parse(comment);

            if(commentToAdd != null)
            {
                UnitOfWork.CommentsItemRepository.Insert(commentToAdd);

                return Request.CreateResponse(HttpStatusCode.Created, Factory.Create(commentToAdd));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Cannot create new comment!!!");
            }
        }
    }
}
