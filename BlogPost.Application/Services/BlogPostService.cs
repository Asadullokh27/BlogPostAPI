using BlogPost.Application.Abstractions;
using BlogPost.Domain.Entities.DTOs;
using BlogPost.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogPost.Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogpostRepository;

        public BlogPostService(IBlogPostRepository bookRepository)
        {
            _blogpostRepository = bookRepository;
        }

        public async Task<string> Post(BlogPostDTO blogpostDTO)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", Guid.NewGuid() + "_" + blogpostDTO.Image.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await blogpostDTO.Image.CopyToAsync(stream);
            }


            var blogpost = new Blogpost()
            {
                Title = blogpostDTO.Title,
                Author = blogpostDTO.Author,
                Comment = blogpostDTO.Comment,
                ContentType = blogpostDTO.ContentType,
                CreatedTime = blogpostDTO.CreatedTime,
                Platform = blogpostDTO.Platform,
                Image = path.Split("wwwroot")[1]
            };

            if (blogpost != null)
            {
                await _blogpostRepository.Create(blogpost);
                return "Added";
            }
            return "Failed";
        }

        public async Task<string> Delete(int id)
        {
            var result = await _blogpostRepository.Delete(x => x.BlogPostId == id);
            if (result)
            {
                return "Deleted";
            }
            else
            {
                return "Failed";
            }

        }

        public async Task<List<Blogpost>> GetAllBlogPosts()
        {
            var result = await _blogpostRepository.GetAll();
            return result.ToList();
        }

        public async Task<List<Blogpost>> GetByTitle(string title)
        {
            var result = await _blogpostRepository.GetAll();
            return result.Where(x => x.Title == title).ToList();
        }

        public async Task<List<Blogpost>> GetBlogPostByContentType(string contenttype)
        {
            var result = await _blogpostRepository.GetAll();
            return result.Where(x => x.ContentType == contenttype).ToList();
        }
        public async Task<Blogpost> GetBlogPostById(int id)
        {
            var result = await _blogpostRepository.GetByAny(x => x.BlogPostId == id);
            return result;
        }
        public async Task<List<Blogpost>> GetBlogPostByAuthor(string authorName)
        {
            var result = await _blogpostRepository.GetAll();
            return result.Where(x => x.Author == authorName).ToList();
        }
        public async Task<string> Update(int id, BlogPostDTO blogpostDTO)
        {
            var res = await _blogpostRepository.GetByAny(x => x.BlogPostId == id);

            if (res != null)
            {


                res.Title = blogpostDTO.Title;
                res.Author = blogpostDTO.Author;
                res.Comment = blogpostDTO.Comment;
                res.ContentType = blogpostDTO.ContentType;
                res.CreatedTime = blogpostDTO.CreatedTime;
                res.Platform = blogpostDTO.Platform;


                var result = await _blogpostRepository.Update(res);
                if (result != null)
                {
                    return "Updated";
                }
                return "Failed";
            }
            return "Failed";
        }


    }
}
