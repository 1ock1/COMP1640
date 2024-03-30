using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        public string GenerateCookieToken(User user, IHttpContextAccessor _httpContextAccessor);
        public string GenerateCookieTokenForSelectedRole(User user, string selectedRole);
        public Task<object> CheckRole(string token);
    }
}
