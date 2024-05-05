using Microsoft.Extensions.DependencyInjection;
using EduSync.Common;
using EduSync.DataAccess;
using EduSync.Business;

namespace EduSync.Business
{
    public static class BusinessDependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            RepositoryDependencyRegistry.DependencyRegistry(services, appSettings);
            services.AddTransient<XyzBusiness>();
            services.AddTransient<StudentBusiness>();
            services.AddTransient<SubjectBusiness>();
            services.AddTransient<StaffBusiness>();
            services.AddTransient<RoleBusiness>();
            services.AddTransient<UserBusiness>();
        }
    }
}