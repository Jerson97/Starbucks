using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Starbucks.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StarbucksDbContext>(opt => 
            opt.UseSqlite(configuration.GetConnectionString("SqliteDatabase"))
        );

        return services;
    }
}
