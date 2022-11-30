using Finance.Core.Entities;

namespace Finance.WebApi.Filters;

public class IdPutValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var baseEntity = context.GetArgument<BaseEntity>(0);

        if (baseEntity == null || baseEntity.Id == null || baseEntity.Id <= 0)
        {
            return Results.BadRequest();
        }

        return await next(context);
    }
}
