using Finance.Core.Entities;

namespace Finance.WebApi.Filters;

public class IncomeValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var income = context.GetArgument<Income>(0);

        if (income == null
        || income.Id <= 0
        || income.Amount <= 0
        || income.IncomeCategoryId == null
        || income.IncomeCategoryId <= 0)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
