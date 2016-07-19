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

        public async Task<Blog> Parse(BlogDTO blogDTOObj)
        {
            if(blogDTOObj == null)
            {

            }

            if(blogDTOObj.Blog_Number != 0)
            {
                return await ParseForEdit(blogDTOObj);
            }
            else if(blogDTOObj.Blog_Number == 0)
            {
                return ParseForAdd(blogDTOObj);
            }
            else
            {
                throw new NotSupportedException("This operation cannot be supported for this object!!!");
            }
        }

        #region for edit and parse for add methods

        private Blog ParseForAdd(BlogDTO blogDtoObj)
        {
            Blog blog = new Blog()
            {
                Title = blogDtoObj.Title,
                Author = blogDtoObj.Author,
                Description = blogDtoObj.Description
            };

            return blog;
        }

        private async Task<Blog> ParseForEdit(BlogDTO blogDtoObj)
        {
            var item = await _unit.BlogItemRepository.Get(i => i.Blog_Number == blogDtoObj.Blog_Number);

            Blog blog = item.FirstOrDefault();

            if (blog == null)
            {

            }

            if (blog.Title != blogDtoObj.Title)
            {
                blog.Title = blogDtoObj.Title;
            }

            if (blog.Author != blogDtoObj.Author)
            {
                blog.Author = blogDtoObj.Author;
            }

            if (blog.Description != blogDtoObj.Description)
            {
                blog.Description = blogDtoObj.Description;
            }

            return blog;
        }

        #endregion
    }
}
