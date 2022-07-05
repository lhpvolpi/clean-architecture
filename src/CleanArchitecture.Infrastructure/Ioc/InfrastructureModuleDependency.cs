using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Ioc
{
    public static class InfrastructureModuleDependency
    {
        public static void AddInfrastructureModule(this IServiceCollection service)
        {
            service.AddTransient<IJwtService, JwtService>();
        }
    }
}

