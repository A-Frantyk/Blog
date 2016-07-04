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
    public class BlogController : BaseController.BaseController<BlogDTO, Blog>
    {
        public BlogController(IUnitOfWork unit 
                              ,[Named("BlogFCTR")] IFactory<BlogDTO , Blog> blogFactory)
            : base(unit, blogFactory)
        {
        }

        [HttpGet]
        public IEnumerable<BlogDTO> GetBlog()
        {
            IQueryable<Blog> query;

            query = UnitOfWork.BlogItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }
        
        [HttpPut] 
        public HttpResponseMessage EditBlogEntity([FromBody] Blog blogEntity)
        {
            throw new NotImplementedException();
        }
    }
}
