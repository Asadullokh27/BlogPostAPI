using BlogPost.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Abstractions
{
    public interface IBlogPostRepository : IBaseRepository<Blogpost>
    {

    }
}
