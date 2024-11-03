using Application.Services;
using Application.Services.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = (typeof(DependencyInjection).Assembly);
        
        services.AddValidatorsFromAssembly(assembly)
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<IPasswordManager, PasswordManager>()
            .AddScoped<IUserProfileManager, UserProfileManager>()
            .AddScoped<ITokenService, TokenService>();
        
        return services;
    }
    
    
}