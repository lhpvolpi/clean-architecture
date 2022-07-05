using CleanArchitecture.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core.Ioc
{
    public static class CoreModuleDependency
    {
        public static void AddCoreModule(this IServiceCollection service)
        {
            service.AddScoped<IJwtSettings, JwtSettings>();
        }
    }
}

