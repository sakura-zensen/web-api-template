using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Common.Authorization
{
    public static partial class StartupExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["ApplicationSettings:JwtSecret"]!.ToString());
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = false;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            return services;
        }

        public static IServiceCollection AddAllOriginCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigin",
                builder => builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services) => services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web template API", Version = "v1" });

            var securitySchema = CreateSecuritySchema();
            options.AddSecurityDefinition("Bearer", securitySchema);

            var securityRequirement = CreateSecurityRequirement(securitySchema);
            options.AddSecurityRequirement(securityRequirement);
        });
    }
}
