using Finance.WebApi.Apis.Endpoints;

namespace Finance.WebApi.Apis;

public class IncomeCategoriesApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGroup("/api/v1/incomes/categories")
            .MapIncomeCategoriesEndpoints();
    }
}
