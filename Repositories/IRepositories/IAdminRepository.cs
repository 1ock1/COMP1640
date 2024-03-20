using COMP1640.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        IActionResult UpdateUser(User user);
    }
}
