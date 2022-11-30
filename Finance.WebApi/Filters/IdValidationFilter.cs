namespace Finance.WebApi.Filters;

public class IdValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var id = context.GetArgument<int>(0);

        if (id <= 0)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
