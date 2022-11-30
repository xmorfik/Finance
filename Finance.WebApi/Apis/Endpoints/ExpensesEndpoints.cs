using Finance.Core.Entities;
using Finance.Services.Interfaces;
using Finance.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Finance.WebApi.Apis.Endpoints;

public static class ExpensesEndpoints
{
    public static RouteGroupBuilder MapExpensesEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAll)
            .WithTags("Getters")
            .WithOpenApi();

        group.MapGet("/{id}", GetById)
            .WithTags("Getters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        group.MapPost("/", Post)
            .Accepts<Expense>("application/json")
            .WithTags("Creators")
            .AddEndpointFilter<ExpenseValidationFilter>()
            .AddEndpointFilter<IdPostValidationFilter>()
            .WithOpenApi();

        group.MapPut("/", Put)
            .Accepts<Expense>("application/json")
            .WithTags("Updaters")
            .AddEndpointFilter<ExpenseValidationFilter>()
            .AddEndpointFilter<IdPutValidationFilter>()
            .WithOpenApi();

        group.MapDelete("/{id}", Delete)
            .WithTags("Deleters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        return group;
    }

    private static async Task<IResult> GetAll(IExpensesService expensesService)
    {
        try
        {
            return await expensesService.GetAll() is ICollection<Expense> expenses
            ? Results.Ok(expenses)
            : Results.NotFound();
        }
        catch
        {
            return Results.Problem();
        }
    }

    private static async Task<IResult> GetById(int id, IExpensesService expensesService)
    {
        try
        {
            return await expensesService.Find(id) is Expense expense
            ? Results.Ok(expense)
            : Results.NotFound();
        }
        catch
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> Post([FromBody] Expense expense, IExpensesService expensesService)
    {
        try
        {
            await expensesService.Add(expense);
            return Results.Created($"/{expense.Id}", expense);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> Put([FromBody] Expense expense, IExpensesService expensesService)
    {
        try
        {
            await expensesService.Update(expense);
            return Results.Created($"/{expense.Id}", expense);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> Delete(int id, IExpensesService expensesService)
    {
        try
        {
            await expensesService.Remove(id);
            return Results.Ok();
        }
        catch
        {
            return Results.BadRequest();
        }
    }
}
