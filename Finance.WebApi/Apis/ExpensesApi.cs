using Finance.WebApi.Apis.Endpoints;

namespace Finance.WebApi.Apis;

public class ExpensesApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGroup("/api/v1/expenses")
            .MapExpensesEndpoints();
    }
}
