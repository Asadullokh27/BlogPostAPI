using BlogPost.Domain.Entities.DTOs;
using BlogPost.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Services
{
    public interface IBlogPostService
    {
        public Task<string> Post(BlogPostDTO blogpostDTO);
        public Task<List<Blogpost>> GetAllBlogPosts();
        public Task<Blogpost> GetBlogPostById(int id);
        public Task<List<Blogpost>> GetByTitle(string title);
        public Task<List<Blogpost>> GetBlogPostByContentType(string contenttype);
        public Task<List<Blogpost>> GetBlogPostByAuthor(string authorName);
        public Task<string> Update(int id, BlogPostDTO blogpostDTO);
        public Task<string> Delete(int id);

    }
}
