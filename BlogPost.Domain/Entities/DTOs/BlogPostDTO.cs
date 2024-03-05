using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Entities.DTOs
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ContentType { get; set; }
        public string Comment { get; set; }
        public int CreatedTime { get; set; }
        public string Platform { get; set; }

        public IFormFile? Image { get; set; }
    }
}
