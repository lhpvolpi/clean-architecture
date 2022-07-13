using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Infrastructure.Common;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Ioc
{
    public static class InfrastructureModuleDependency
    {
        public static void AddInfrastructureModule(this IServiceCollection service)
        {
            // settings
            service.AddScoped<IJwtSettings, JwtSettings>();
            service.AddScoped<IMongoDbSettings, MongoDbSettings>();

            // services
            service.AddTransient<IJwtService, JwtService>();
        }
    }
}

