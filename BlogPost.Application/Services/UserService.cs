using BlogPost.Application.Abstractions;
using BlogPost.Domain.Entities.DTOs;
using BlogPost.Domain.Entities.Models;
using BlogPost.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> CreateUser(UserDTO userDTO)
        {
            var res = await _userRepo.GetAll();
            var email = res.Any(x => x.Email == userDTO.Email);
            var login = res.Any(x => x.Login == userDTO.Login);
            if (!email)
            {
                if (!login)
                {
                    var newUser = new User()
                    {
                        FirstName = userDTO.FirstName,
                        LastName = userDTO.LastName,
                        Login = userDTO.Login,
                        Password = userDTO.Password,
                        Email = userDTO.Email,
                        Role = userDTO.Role

                    };
                    await _userRepo.Create(newUser);
                    return "Created";

                }
                return "Registerd Login";
            }
            return "Registered email";
        }

        public async Task<string> DeleteUser(int id)
        {
            var result = await _userRepo.Delete(x => x.UserId == id);
            if (result)
            {
                return "Deleted";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var get = await _userRepo.GetAll();

            var result = get.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;

        }


        public async Task<UserViewModel> GetById(int id)
        {
            var get = await _userRepo.GetByAny(x => x.UserId == id);

            var result = new UserViewModel()
            {
                UserId = get.UserId,
                FirstName = get.FirstName,
                LastName = get.LastName,
                Email = get.Email,
                Role = get.Role

            };

            return result;
        }

        public async Task<List<UserViewModel>> GetByFirstName(string firstName)
        {
            var get = await _userRepo.GetAll();
            var find = get.Where(x => x.FirstName == firstName);

            var result = find.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;
        }





        public async Task<List<UserViewModel>> GetByLastName(string lastName)
        {
            var get = await _userRepo.GetAll();
            var find = get.Where(x => x.LastName == lastName);

            var result = find.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;
        }

        public async Task<List<UserViewModel>> GetByRole(string role)
        {
            var get = await _userRepo.GetAll();
            var find = get.Where(x => x.Role == role);

            var result = find.Select(x => new UserViewModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = x.Role
            }).ToList();
            return result;
        }

        public async Task<string> UpdateUser(int id, UserDTO userDTO)
        {
            var res = await _userRepo.GetAll();
            var email = res.Any(x => x.Email == userDTO.Email);
            var login = res.Any(x => x.Login == userDTO.Login);
            if (!email)
            {
                if (!login)
                {
                    var old = await _userRepo.GetByAny(x => x.UserId == id);

                    if (old == null) return "Failed";
                    old.FirstName = userDTO.FirstName;
                    old.LastName = userDTO.LastName;
                    old.Login = userDTO.Login;
                    old.Password = userDTO.Password;
                    old.Email = userDTO.Email;
                    old.Role = userDTO.Role;


                    await _userRepo.Update(old);
                    return "Updated";

                }
                return "Registerd Login";
            }
            return "Registerd Login";
        }
    }

}
