using Finance.Services;
using Finance.Services.Interfaces;

namespace Finance.WebApi.Extentions;

public static class ConfigureServicesExtention
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IIncomesService, IncomesService>();
        services.AddScoped<IExpensesService, ExpensesService>();
        services.AddScoped<IIncomeCategoriesService, IncomeCategoriesService>();
        services.AddScoped<IExpenseCategoriesService, ExpenseCategoriesService>();
        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}
