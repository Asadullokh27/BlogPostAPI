using BlogPost.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Services
{
    public interface IAuthorizationService
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin request);

    }
}
