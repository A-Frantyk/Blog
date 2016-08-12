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
    [RoutePrefix("api/blog")]
    [AllowAnonymous]
    public class BlogController : BaseController.BaseController<BlogDTO, Blog>
    {
        public BlogController(IUnitOfWork unit, [Named("BlogFCTR")] IFactory<BlogDTO , Blog> blogFactory)
            : base(unit, blogFactory)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<BlogDTO>> GetBlog()
        {
            IQueryable<Blog> query;

            query = await UnitOfWork.BlogItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> GetBlogByID(int id)
        {
            var blog = await UnitOfWork.BlogItemRepository.GetByIdAsync(id);

            if(blog != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(blog));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("author")]
        public async Task<HttpResponseMessage> GetAuthor()
        {
            var item = await UnitOfWork.BlogItemRepository.Get();

            var author = item.FirstOrDefault().Author;

            return Request.CreateResponse(HttpStatusCode.OK, author);
        }

        [HttpGet]
        [Route("description")]
        public async Task<HttpResponseMessage> GetDescription()
        {
            var item = await UnitOfWork.BlogItemRepository.Get();

            var description = item.FirstOrDefault().Description;

            return Request.CreateResponse(HttpStatusCode.OK, description);
        }

        [HttpGet]
        [Route("title")]
        public async Task<HttpResponseMessage> GetTitle()
        {
            var item = await UnitOfWork.BlogItemRepository.Get();

            var title = item.FirstOrDefault().Title;

            return Request.CreateResponse(HttpStatusCode.OK, title);
        }

        [HttpPut] 
        [Route("edit")]
        public async Task<HttpResponseMessage> EditBlogEntity([FromBody] BlogDTO blogEntity)
        {
            var blog = await Factory.Parse(blogEntity);
            UnitOfWork.BlogItemRepository.Update(blog);

            return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(blog));
        }
    }
}
