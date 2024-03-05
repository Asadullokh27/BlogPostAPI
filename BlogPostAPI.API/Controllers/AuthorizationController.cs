using BlogPost.Application.Services;
using BlogPost.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authSevice;
        public AuthorizationController(IAuthorizationService authService)
        {
            _authSevice = authService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Login([FromForm] RequestLogin model)
        {
            var result = await _authSevice.GenerateToken(model);

            return Ok(result);
        }
    }
}
