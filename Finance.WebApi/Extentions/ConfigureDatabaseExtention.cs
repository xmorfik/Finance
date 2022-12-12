using Microsoft.EntityFrameworkCore;

namespace Finance.WebApi.Extentions;

public static class ConfigureDatabaseExtention
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Infrastructure.Data.FinanceDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DockerSqlServer")));

        return services;
    }
}
