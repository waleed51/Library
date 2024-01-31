using Library.Core.Interfaces.Common;
using Library.Infrastructure.Persistence.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Persistence.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQueryManager, QueryManager>();

            return services;
        }

    }
}
