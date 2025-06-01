using Common.Infrastructure.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure;

public static partial class StartupExtensions
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(configuration, "connection-string-property");

        return services;
    }
    public static async Task<IApplicationBuilder> AddCustomIdentityUserRoles(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppUserRole>>();
        // Ensure the database is created and migrations are applied
        // Customize the roles as needed
        AppUserRole[] roles = [
            new AppUserRole { DisplayName = "Admin", Name = "Admin"},
            new AppUserRole { DisplayName = "Standard User", Name = "User" }
        ];
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!))
            {
                await roleManager.CreateAsync(role);
            }
        }

        return app;
    }
}
