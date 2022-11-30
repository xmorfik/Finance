using Finance.Core.Entities;

namespace Finance.WebApi.Filters;

public class IncomeCategoriesValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var incomeCategory = context.GetArgument<IncomeCategory>(0);

        if (incomeCategory == null
        || incomeCategory.Name == null
        || incomeCategory.Name.Length == 0
        || incomeCategory.Name.Length > 50)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
