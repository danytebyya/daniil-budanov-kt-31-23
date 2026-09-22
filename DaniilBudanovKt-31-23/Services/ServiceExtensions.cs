using DaniilBudanovKt_31_23.Services.Implementations;
using DaniilBudanovKt_31_23.Services.Interfaces;

namespace DaniilBudanovKt_31_23.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabaseServices(
            this IServiceCollection services)
        {
            services.AddScoped<IAcademicGroupService, AcademicGroupService>();

            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<ISubjectService, SubjectService>();

            services.AddScoped<IGradeService, GradeService>();

            services.AddScoped<IPerformanceService, PerformanceService>();

            return services;
        }
    }
}