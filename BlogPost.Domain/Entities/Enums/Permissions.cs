using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Entities.Enums
{
    public enum Permissions
    {
        Post = 1,
        GetBlogPostById = 2,
        GetAllBlogPosts=3,
        GetByTitle=4,
        GetBlogPostByContentType = 5,
        GetBlogPostByAuthor=6,
        Update=7,
        Delete=8,
        CreateUser=9,
        GetAllUsers=10,
        GetByUserId=11,
        GetByUserFirstName=12,
        GetByUserLastName=13,
        GetByRole=14,
        UpdateUser=15,
        DeleteUser=16,
    }
}
