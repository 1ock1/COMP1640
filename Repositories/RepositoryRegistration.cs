using COMP1640.Repositories.IRepositories;
using COMP1640.Repositories.Services.AcademicService;
using COMP1640.Repositories.Services.AdminService;
using COMP1640.Repositories.Services.TopicServices;
using COMP1640.Repositories.Services.UserService;


namespace COMP1640.Repositories
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IAdminRepository, AdminService>();
            services.AddScoped<ITopicRepository, TopicService>();
            services.AddScoped<IAcademicRepository, AcademicService>();
        }
    }
}
