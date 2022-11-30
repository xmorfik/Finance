using Finance.Core.Entities;

namespace Finance.WebApi.Filters;

public class ExpenseValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var expense = context.GetArgument<Expense>(0);

        if (expense == null
        || expense.Id <= 0
        || expense.Amount >= 0
        || expense.ExpenseCategoryId == null
        || expense.ExpenseCategoryId <= 0)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
