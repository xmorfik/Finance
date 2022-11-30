using Finance.Repositories;
using Finance.Repositories.Interfaces;

namespace Finance.WebApi.Configurations;

public static class ConfigureRepositoryExtention
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
    }
}
