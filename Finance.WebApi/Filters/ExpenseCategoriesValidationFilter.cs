using Finance.Core.Entities;

namespace Finance.WebApi.Filters;

public class ExpenseCategoriesValidationFilter:IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var expenseCategory = context.GetArgument<ExpenseCategory>(0);

        if (expenseCategory == null
        || expenseCategory.Name == null
        || expenseCategory.Name.Length == 0 
        || expenseCategory.Name.Length > 50)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
