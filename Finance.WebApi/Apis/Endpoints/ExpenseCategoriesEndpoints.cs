using Finance.Core.Entities;
using Finance.Services.Interfaces;
using Finance.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Finance.WebApi.Apis.Endpoints;

public static class ExpenseCategoriesEndpoints
{
    public static RouteGroupBuilder MapExpenseCategoryEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAll)
            .WithTags("Getters")
            .WithOpenApi();

        group.MapGet("/{id}", GetById)
            .WithTags("Getters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        group.MapPost("/", Post)
            .Accepts<ExpenseCategory>("application/json")
            .WithTags("Creators")
            .AddEndpointFilter<ExpenseCategoriesValidationFilter>()
            .AddEndpointFilter<IdPostValidationFilter>()
            .WithOpenApi();

        group.MapPut("/", Put)
            .Accepts<ExpenseCategory>("application/json")
            .WithTags("Updaters")
            .AddEndpointFilter<ExpenseCategoriesValidationFilter>()
            .AddEndpointFilter<IdPutValidationFilter>()
            .WithOpenApi();

        group.MapDelete("/{id}", Delete)
            .WithTags("Deleters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        return group;
    }

    private static async Task<IResult> GetAll(IExpenseCategoriesService expenseCategoriesService)
    {
        try
        {
            return await expenseCategoriesService.GetAll() is ICollection<ExpenseCategory> expenseCategory
            ? Results.Ok(expenseCategory)
            : Results.NotFound();
        }
        catch
        {
            return Results.Problem();
        }
    }

    private static async Task<IResult> GetById(int id, IExpenseCategoriesService expenseCategoriesService)
    {
        try
        {
            return await expenseCategoriesService.Find(id) is ExpenseCategory expenseCategory
            ? Results.Ok(expenseCategory)
            : Results.NotFound();
        }
        catch
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> Post([FromBody] ExpenseCategory expenseCategory, IExpenseCategoriesService expenseCategoriesService)
    {
        try
        {
            await expenseCategoriesService.Add(expenseCategory);
            return Results.Created($"/{expenseCategory.Id}", expenseCategory);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> Put([FromBody] ExpenseCategory expenseCategory, IExpenseCategoriesService expenseCategoriesService)
    {
        try
        {
            await expenseCategoriesService.Update(expenseCategory);
            return Results.Created($"/{expenseCategory.Id}", expenseCategory);
        }
        catch
        {
            return Results.BadRequest();
        }

    }

    private static async Task<IResult> Delete(int id, IExpenseCategoriesService expenseCategoriesService)
    {
        try
        {
            await expenseCategoriesService.Remove(id);
            return Results.Ok();
        }
        catch
        {
            return Results.BadRequest();
        }
    }
}
