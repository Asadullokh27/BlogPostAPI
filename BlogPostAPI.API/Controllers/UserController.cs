using BlogPost.Application.Services;
using BlogPost.Domain.Entities.DTOs;
using BlogPost.Domain.Entities.Enums;
using BlogPost.Domain.Entities.ViewModels;
using BlogPostAPI.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateUser)]
        public async Task<string> CreateUser([FromForm] UserDTO userDTO)
        {
            return await _userService.CreateUser(userDTO);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllUsers)]
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            return await _userService.GetAll();
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetByUserId)]
        public async Task<UserViewModel> GetByUserId(int id)
        {
            return await _userService.GetById(id);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetByRole)]
        public async Task<List<UserViewModel>> GetByRole(string role)
        {
            return await _userService.GetByRole(role);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetByUserFirstName)]
        public async Task<List<UserViewModel>> GetByUserFirstName(string firstname)
        {
            return await _userService.GetByFirstName(firstname);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetByUserLastName)]
        public async Task<List<UserViewModel>> GetByUserLastName(string lastname)
        {
            return await _userService.GetByLastName(lastname);
        }
        [HttpPut]
        [IdentityFilter(Permissions.UpdateUser)]
        public async Task<string> UpdateUser(int id, UserDTO userDTO)
        {
            return await _userService.UpdateUser(id, userDTO);
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteUser)]
        public async Task<string> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
