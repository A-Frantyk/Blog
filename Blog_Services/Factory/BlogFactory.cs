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
    public class BlogFactory : IFactory<BlogDTO, Blog>
    {
        private readonly IUnitOfWork _unit;

        public BlogFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public BlogDTO Create(Blog blogObj)
        {
            if(blogObj == null)
            {

            }

            var blogDTO = new BlogDTO()
            {
                Blog_Number = blogObj.Blog_Number,
                Title = blogObj.Title,
                Author = blogObj.Author,
                Description = blogObj.Description
            };

            return blogDTO;
        }

        public Blog Parse(BlogDTO blogDTOObj)
        {
            throw new NotImplementedException();
        }
    }
}
