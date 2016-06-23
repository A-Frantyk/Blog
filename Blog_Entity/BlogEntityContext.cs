using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog_Entity
{
    public class BlogEntityContext : DbContext
    {
        public BlogEntityContext()
            : base("name=BlogEntityContext")
        {

        }
    }
}
