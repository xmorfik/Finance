using Finance.Core.Entities;

namespace Finance.WebApi.Filters;

public class IdPostValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var baseEntity = context.GetArgument<BaseEntity>(0);

        if (baseEntity == null || baseEntity.Id != null)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
