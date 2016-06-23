using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog_Entity.Model;

namespace Blog_Entity
{
    public class BlogEntityContext : DbContext
    {
        public BlogEntityContext()
            : base("name=BlogEntityContext")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
