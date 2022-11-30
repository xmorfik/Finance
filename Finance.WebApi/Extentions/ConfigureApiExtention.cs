using Finance.WebApi.Apis;
using Finance.WebApi.Filters;

namespace Finance.WebApi.Configurations;

public static class ConfigureApiExtention
{
    public static IServiceCollection AddApis(this IServiceCollection services)
    {
        services.AddTransient<IApi, IncomesApi>();
        services.AddTransient<IApi, ExpensesApi>();
        services.AddTransient<IApi, ReportsApi>();
        services.AddTransient<IApi, ExpenseCategoriesApi>();
        services.AddTransient<IApi, IncomeCategoriesApi>();

        services.AddSingleton<IdValidationFilter>();
        services.AddSingleton<IncomeValidationFilter>();
        services.AddSingleton<ExpenseValidationFilter>();
        services.AddSingleton<IncomeCategoriesValidationFilter>();
        services.AddSingleton<ExpenseCategoriesValidationFilter>();

        return services;
    }
}
