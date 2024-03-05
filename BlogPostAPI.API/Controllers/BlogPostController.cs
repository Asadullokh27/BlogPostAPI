using BlogPost.Application.Services;
using BlogPost.Domain.Entities.DTOs;
using BlogPost.Domain.Entities.Enums;
using BlogPost.Domain.Entities.Models;
using BlogPostAPI.API.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace BlogPostAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {

        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogpostService)
        {
             _blogPostService = blogpostService;
        }


        [HttpPost]
        [IdentityFilter(Permissions.Post)]
        public async Task<string> Post(BlogPostDTO model)
        {
            var result = await _blogPostService.Post(model);

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetBlogPostById)]
        public async Task<Blogpost> GetBlogPostById(int id)
        {
            return await _blogPostService.GetBlogPostById(id);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllBlogPosts)]
        public async Task<List<Blogpost>> GetAllBlogPosts()
        {
            var result = await _blogPostService.GetAllBlogPosts();

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetByTitle)]
        public async Task<List<Blogpost>> GetByTitle(string title)
        {
            var result = await _blogPostService.GetByTitle(title);

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetBlogPostByContentType)]
        public async Task<List<Blogpost>> GetBlogPostByContentType(string content)
        {
            return await _blogPostService.GetBlogPostByContentType(content);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetBlogPostByAuthor)]
        public async Task<List<Blogpost>> GetBlogPostByAuthor(string author)
        {
            return await _blogPostService.GetBlogPostByAuthor(author);
        }

        [HttpPut]
        [IdentityFilter(Permissions.Update)]
        public async Task<string> Update(int id, BlogPostDTO blogDTO)
        {
            return await _blogPostService.Update(id, blogDTO);
        }
        [HttpDelete]
        [IdentityFilter(Permissions.Delete)]
        public async Task<string> Delete(int id)
        {
            return await _blogPostService.Delete(id);
        }

    }
}
