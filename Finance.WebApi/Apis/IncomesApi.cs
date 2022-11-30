using Finance.WebApi.Apis.Endpoints;

namespace Finance.WebApi.Apis;

public class IncomesApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGroup("/api/v1/incomes")
            .MapIncomesEndpoints();
    }
}
