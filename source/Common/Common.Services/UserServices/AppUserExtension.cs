using Common.Services.RequestDtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Common.Services.UserServices
{
    public static partial class AppUserExtension
    {
        public static IEndpointRouteBuilder AddAppUserApis(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/signup", async (
                IAppUserManager userManager,
                [FromBody] AppUserRequestDto requestDto
                ) => await userManager.UpsertAsync(requestDto))
            .WithTags("App User")
            .RequireAuthorization();

            app.MapPost("/api/signin", async (
                IAppUserManager userManager,
                [FromBody] AppUserRequestDto requestDto
                ) => await userManager.UpsertAsync(requestDto))
             .WithTags("App User")
            .RequireAuthorization();
            
            return app;
        }
    }
}
