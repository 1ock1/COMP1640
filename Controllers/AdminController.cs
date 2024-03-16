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
        
    }
}
