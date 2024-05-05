using EduSync.Business;
using EduSync.Common;

namespace EduSync.Web.API.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(appSettings);
            services.AddScoped<ApplicationContext>();
            BusinessDependencyRegistry.RegisterDependency(services, appSettings);
        }
    }
}
