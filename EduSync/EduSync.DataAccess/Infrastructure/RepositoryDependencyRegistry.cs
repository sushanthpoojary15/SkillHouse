using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EduSync.Common;
using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;

namespace EduSync.DataAccess
{
    public static class RepositoryDependencyRegistry
    {
        public static void DependencyRegistry(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<EduSyncContext>(options =>
            {
                options.UseSqlServer(appSettings.DbConnectionString);
            });

            services.AddTransient<IXyzRepository, XyzRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();


            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

    }
}
