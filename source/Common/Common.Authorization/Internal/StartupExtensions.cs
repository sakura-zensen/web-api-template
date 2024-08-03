using Microsoft.OpenApi.Models;

namespace Common.Authorization
{
    static partial class StartupExtensions
    {
        private static OpenApiSecurityScheme CreateSecuritySchema() => new()
        {
            Description = "JWT Authorization header using the bearer scheme",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };

        private static OpenApiSecurityRequirement CreateSecurityRequirement(OpenApiSecurityScheme securitySchema) => new()
        {
          {securitySchema, ["Bearer"]}
        };
    }
}
