using BlogPost.Application.Abstractions;
using BlogPost.Domain.Entities.Models;
using BlogPost.Infrastucture.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastucture.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BlogPostDbContext context) : base(context)
        {
        }
    }
}
