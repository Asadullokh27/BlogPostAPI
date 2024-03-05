using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Entities.Models
{
    public class Blogpost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
        public string ContentType { get; set; }
        public int CreatedTime { get; set; }
        public string Platform { get; set; }
        public string? Image { get; set; }

    }
}
