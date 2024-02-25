using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Repositories.Services.UserService
{
    public class UserService : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<List<User>> GetUser()
        {
            var users = await this._dataContext.User.ToListAsync();
            return users;
        }
    }
}
