using COMP1640.Repositories.IRepositories;
using COMP1640.Repositories.Services.AuthService;
using COMP1640.Repositories.Services.AdminService;
using COMP1640.Repositories.Services.UserService;
using COMP1640.Repositories.Services.FilesService;
using COMP1640.Repositories.Services.ReportRepository;
using COMP1640.Repositories.Services.TopicService;
using COMP1640.Repositories.Services.AcademicService;
using COMP1640.Repositories.Services.FileReportRepository;
using COMP1640.Repositories.Services.NotificationServices;
using COMP1640.Repositories.Services.ReportCommentServices;
using COMP1640.Repositories.Services.PublishedReportServices;
using COMP1640.Services;


namespace COMP1640.Repositories
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IAuthRepository, AuthService>();
            services.AddScoped<IAdminRepository, AdminService>();
            services.AddScoped<IFileRepository, FileServices>();
            services.AddScoped<IReportRepository, ReportServices>();
            services.AddScoped<ITopicRepository,TopicService>();
            services.AddScoped<IAcademicRepository, AcademicService>();
            services.AddScoped<IFileReportRepository, FileReportServices>();
            services.AddScoped<INotificationRepository, NotificationService>();
            services.AddScoped<IReportCommentRepository, ReportCommentServices>();
            services.AddScoped<IPublishedReportRepository, PublishedReportService>();
            services.AddScoped<IFacultyRepository, FacultyService>();
        }
    }
}
