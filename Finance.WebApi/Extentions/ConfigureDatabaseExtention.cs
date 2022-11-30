using Microsoft.EntityFrameworkCore;

namespace Finance.WebApi.Configurations;

public static class ConfigureDatabaseExtention
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Infrastructure.Data.FinanceDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("LocalServer")));

        return services;
    }
}
