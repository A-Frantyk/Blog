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
    public class CommentsController : BaseController.BaseController<CommentsDTO, Comments>
    {
        public CommentsController(IUnitOfWork unit, [Named("CommentsFCTR")] IFactory<CommentsDTO, Comments> commentFactory) : base(unit, commentFactory)
        {
        }

        [HttpGet]
        public IEnumerable<CommentsDTO> GetComments()
        {
            IQueryable<Comments> query;

            query = UnitOfWork.CommentsItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }
    }
}
