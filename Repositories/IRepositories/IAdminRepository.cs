using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        public IEnumerable<User> GetAllUsers();
    }
}
