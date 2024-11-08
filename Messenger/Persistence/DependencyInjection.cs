using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<ApplicationDbContext>(o =>
            o.UseNpgsql(connectionString, 
                optionsAction => optionsAction.MigrationsHistoryTable("Migrations", "migration")));
    }
}