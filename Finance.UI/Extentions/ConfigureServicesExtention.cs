using Finance.Core.Entities;
using Finance.UI.Services;
using Finance.UI.Interfaces;
using Finance.Services.Interfaces;

namespace Finance.UI.Extentions;

public static class ConfigureServicesExtention
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRequestApi<Income>, IncomesService>();
        services.AddScoped<IRequestApi<IncomeCategory>, IncomeCategoriesService>();
        services.AddScoped<IRequestApi<Expense>, ExpensesService>();
        services.AddScoped<IRequestApi<ExpenseCategory>, ExpenseCategoriesService>();
        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}
