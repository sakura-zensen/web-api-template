using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure
{
    public partial class StartupExtensions
    {
        private static IServiceCollection AddDbContext<TContext>(this IServiceCollection services, IConfiguration configuration, string connectionStringName) where TContext : IdentityDbContext
        {
            services.AddDbContext<TContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(connectionStringName), options => options.EnableRetryOnFailure())
                );

            return services;
        }
    }
}
