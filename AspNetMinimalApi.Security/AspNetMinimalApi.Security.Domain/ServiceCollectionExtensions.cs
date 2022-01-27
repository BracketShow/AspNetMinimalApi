using AspNetMinimalApi.Security.Domain.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetMinimalApi.Security.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSecurityDomain(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthorization((options) => { PoliciesConfiguration.ConfigurePolicies(options); })
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(ConfigureJwtBearer);

        return services;
    }

    private static void ConfigureJwtBearer(JwtBearerOptions configureOptions)
    {
        configureOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost/",
            ValidAudience = "https://localhost/",
            IssuerSigningKey = ConfigureSecurityKey()
        };

        static SymmetricSecurityKey ConfigureSecurityKey()
        {
            var bytes = Encoding.UTF8.GetBytes("super_secret_key_with_numbers_123987");
            return new SymmetricSecurityKey(bytes);
        }
    }
}
