using Common.Services.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Authorization;

public partial class IntrospectManager(IOptions<ApplicationSettingsModel> options)
{
    private ClaimsPrincipal? ValidateTokenAsync(string token)
    {
        var validationParameters = GetValidationParameters();
        return new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out _);
    }

    private TokenValidationParameters GetValidationParameters() => new()
    {
        IssuerSigningKey = new SymmetricSecurityKey(GetEncodedSigningKey()),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };

    private byte[] GetEncodedSigningKey() => Encoding.UTF8.GetBytes(options.Value.JwtSecret ?? string.Empty);
}
