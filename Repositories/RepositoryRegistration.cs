using COMP1640.Repositories.IRepositories;
using COMP1640.Repositories.Services.UserService;

namespace COMP1640.Repositories
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserService>();
        }
    }
}
