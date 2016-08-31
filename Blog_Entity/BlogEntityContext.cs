using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog_Entity.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Entity
{
    public class BlogEntityContext : DbContext
    {
        public BlogEntityContext()
            : base("name=BlogEntityContext")
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Writes> Writes { get; set; }

        public DbSet<UserCredentials> UserCredentials { get; set; }

        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredentials>()
                        .HasOptional(s => s.User)
                        .WithOptionalPrincipal(a => a.UserCredentials);
        }
    }
}
