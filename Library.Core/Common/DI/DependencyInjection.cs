using Library.Core.Books.Interfaces;
using Library.Core.Books.Queries;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Reflection;
using Library.Core.Interfaces.Common;
using Library.Core.Common.Models;
using Library.Core.Common.Services;

namespace Library.Core.Common.DI
{
    public static class DependencyInjection
    {
        public static void RegisterCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            services.AddHttpContextAccessor();
            ConfigureOptions(services, configuration);
            ConfigureMediatR(services);
            ConfigureQueries(services);
            ConfigureServices(services);
        }

        private static void ConfigureQueries(IServiceCollection services)
        {
            services.AddScoped<IBookQueries, BookDapperQueries>();
        }
        
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IValidationService, ValidationService>();
        }

        private static void ConfigureMediatR(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        private static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }

    }
}
