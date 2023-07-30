using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.Infrastructure.Authentication;
using BubberDinner.Infrastructure.Persistence;
using BubberDinner.Infrastructure.Persistence.Repositories;
using BubberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BubberDinner.Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuthServices(configuration);
        services.AddPersistence();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BubberDinnerDbContext>(options =>
            options.UseSqlServer());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
    }

    private static void AddAuthServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true, 
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });
    }
}
