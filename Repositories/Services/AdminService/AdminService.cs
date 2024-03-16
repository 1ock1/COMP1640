using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;

namespace COMP1640.Repositories.Services.AdminService
{
    public class AdminService : IAdminRepository
    {

        private readonly DataContext _dataContext;
        public AdminService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _dataContext.User.ToList();
                                    
        }
    }
}
