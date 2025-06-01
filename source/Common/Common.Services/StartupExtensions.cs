using Common.Authorization;
using Common.Services.Models;
using Common.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Common.Services;

public static class StartupExtensions
{
    public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApplicationSettingsModel>(configuration.GetSection(ApplicationSettingsModel.ApplicationSettings));

        services.AddScoped<IIntrospectManager, IntrospectManager>();
        services.AddScoped<IAppUserManager, AppUserManager>();

        return services;
    }

    public static IEndpointRouteBuilder AddIdentityApis(this IEndpointRouteBuilder app)
    {
        app.MapGroup("/api").MapIdentityApi<AppUser>().WithTags("Identity Apis").RequireAuthorization();
        app.AddAppUserApis();

        return app;
    }
}
