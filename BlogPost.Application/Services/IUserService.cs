using BlogPost.Domain.Entities.DTOs;
using BlogPost.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Services
{
    public interface IUserService
    {

        public Task<string> CreateUser(UserDTO userDTO);
        public Task<List<UserViewModel>> GetAll();
        public Task<List<UserViewModel>> GetByFirstName(string FirstName);
        public Task<List<UserViewModel>> GetByLastName(string LastName);
        public Task<UserViewModel> GetById(int id);
        public Task<List<UserViewModel>> GetByRole(string role);
        public Task<string> UpdateUser(int id, UserDTO userDTO);
        public Task<string> DeleteUser(int id);

    }
}
