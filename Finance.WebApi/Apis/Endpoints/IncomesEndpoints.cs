using Finance.Core.Entities;
using Finance.Services.Interfaces;
using Finance.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Finance.WebApi.Apis.Endpoints;

public static class IncomesEndpoints
{
    public static RouteGroupBuilder MapIncomesEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAll)
            .WithTags("Getters")
            .WithOpenApi();

        group.MapGet("/{id}", GetById)
            .WithTags("Getters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        group.MapPost("/", Post)
            .Accepts<Income>("application/json")
            .WithTags("Creators")
            .AddEndpointFilter<IncomeValidationFilter>()
            .AddEndpointFilter<IdPostValidationFilter>()
            .WithOpenApi();

        group.MapPut("/", Put)
            .Accepts<Income>("application/json")
            .WithTags("Updaters")
            .AddEndpointFilter<IncomeValidationFilter>()
            .AddEndpointFilter<IdPutValidationFilter>()
            .WithOpenApi();

        group.MapDelete("/{id}", Delete)
            .WithTags("Deleters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        return group;
    }

    private static async Task<IResult> GetAll(IIncomesService incomesService)
    {
        try
        {
            return await incomesService.GetAll() is ICollection<Income> incomes
            ? Results.Ok(incomes)
            : Results.NotFound();
        }
        catch
        {
            return Results.Problem();
        }
    }

    private static async Task<IResult> GetById(int id, IIncomesService incomesService)
    {
        try
        {
            return await incomesService.Find(id) is Income income
            ? Results.Ok(income)
            : Results.NotFound();
        }
        catch
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> Post([FromBody] Income income, IIncomesService incomesService)
    {
        try
        {
            await incomesService.Add(income);
            return Results.Created($"/{income.Id}", income);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> Put([FromBody] Income income, IIncomesService incomesService)
    {
        try
        {
            await incomesService.Update(income);
            return Results.Created($"/{income.Id}", income);
        }
        catch
        {
            return Results.BadRequest();
        }

    }

    private static async Task<IResult> Delete(int id, IIncomesService incomesService)
    {
        try
        {
            await incomesService.Remove(id);
            return Results.Ok();
        }
        catch
        {
            return Results.BadRequest();
        }
    }
}
