using COMP1640.Repositories.IRepositories;
using COMP1640.Repositories.Services.AuthService;
using COMP1640.Repositories.Services.AdminService;
using COMP1640.Repositories.Services.UserService;
using COMP1640.Repositories.Services.TopicService;
using COMP1640.Repositories.Services.AcademicService;


namespace COMP1640.Repositories
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IAuthRepository, AuthService>();
            services.AddScoped<IAdminRepository, AdminService>();
            services.AddScoped<ITopicRepository,TopicService>();
            services.AddScoped<IAcademicRepository, AcademicService>();
        }
    }
}
