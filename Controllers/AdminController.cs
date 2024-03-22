using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }


        [HttpGet("GetAllUser")]
        public IEnumerable<User> GetAllUsers()
        {
            // Call the service to get all users
            IEnumerable<User> users = _adminRepository.GetAllUsers();
            return users;
        }

        [HttpGet("GetUserById")]
        public User GetUserById(int id)
        {
            // Call the service to get user by id
            User user = _adminRepository.GetUserById(id);
            return user;
        }

        [HttpPut("UpdateUser")]
        public User UpdateUser(int id, UserUpdateDTO user)
        {
            // Call the service to update user

            User userInformation = _adminRepository.GetUserById(id);

        
            userInformation.Name =  user.Name;
            userInformation.PhoneNumber = user.PhoneNumber;
            userInformation.BirthDate = user.BirthDate;
            userInformation.Email = user.Email;
            userInformation.Password = user.Password;
            userInformation.Status = user.Status;

            _adminRepository.UpdateUser(userInformation);
            return userInformation;
        }

    }
}
