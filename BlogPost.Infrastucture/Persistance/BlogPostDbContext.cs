using BlogPost.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastucture.Persistance
{
    public class BlogPostDbContext:DbContext
    {

        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options)
    : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blogpost> BlogPosts { get; set; }

    }
}
