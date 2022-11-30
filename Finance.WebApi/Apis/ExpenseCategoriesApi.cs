using Finance.WebApi.Apis.Endpoints;

namespace Finance.WebApi.Apis;

public class ExpenseCategoriesApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGroup("/api/v1/expenses/categories")
            .MapExpenseCategoryEndpoints();
    }
}
