using EDU.Domain.Repositories;
using EDU.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace EDU.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
