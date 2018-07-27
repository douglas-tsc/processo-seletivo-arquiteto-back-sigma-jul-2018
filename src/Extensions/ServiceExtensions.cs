using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities;
using Sigma.PatrimonioApi.Repository;

namespace Sigma.PatrimonioApi.Extensions
{
    public static class ServiceExtensions
    {
        // services.ConfigureCors();
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        // services.ConfigureRepositoryWrapper();
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddSingleton<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        }

        // services.ConfigureSqlServerContext(Configuration);
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = @"Data Source=127.0.0.1; Initial Catalog=DbTest; Integrated Security=SSPI;";
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
