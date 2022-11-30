using Finance.Core.Entities;
using Finance.Services.Interfaces;
using Finance.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Finance.WebApi.Apis.Endpoints;

public static class IncomeCategoriesEndpoints
{
    public static RouteGroupBuilder MapIncomeCategoriesEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAll)
            .WithTags("Getters")
            .WithOpenApi();

        group.MapGet("/{id}", GetById)
            .WithTags("Getters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        group.MapPost("/", Post)
            .Accepts<IncomeCategory>("application/json")
            .WithTags("Creators")
            .AddEndpointFilter<IncomeCategoriesValidationFilter>()
            .AddEndpointFilter<IdPostValidationFilter>()
            .WithOpenApi();

        group.MapPut("/", Put)
            .Accepts<IncomeCategory>("application/json")
            .WithTags("Updaters")
            .AddEndpointFilter<IncomeCategoriesValidationFilter>()
            .AddEndpointFilter<IdPutValidationFilter>()
            .WithOpenApi();

        group.MapDelete("/{id}", Delete)
            .WithTags("Deleters")
            .AddEndpointFilter<IdValidationFilter>()
            .WithOpenApi();

        return group;
    }

    private static async Task<IResult> GetAll(IIncomeCategoriesService incomeCategoryCategoriesService)
    {
        try
        {
            return await incomeCategoryCategoriesService.GetAll() is ICollection<IncomeCategory> incomeCategoryCategory
            ? Results.Ok(incomeCategoryCategory)
            : Results.NotFound();
        }
        catch
        {
            return Results.Problem();
        }
    }

    private static async Task<IResult> GetById(int id, IIncomeCategoriesService incomeCategoryCategoriesService)
    {
        try
        {
            return await incomeCategoryCategoriesService.Find(id) is IncomeCategory incomeCategoryCategory
            ? Results.Ok(incomeCategoryCategory)
            : Results.NotFound();
        }
        catch
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> Post([FromBody] IncomeCategory incomeCategoryCategory, IIncomeCategoriesService incomeCategoryCategoriesService)
    {
        try
        {
            await incomeCategoryCategoriesService.Add(incomeCategoryCategory);
            return Results.Created($"/{incomeCategoryCategory.Id}", incomeCategoryCategory);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> Put([FromBody] IncomeCategory incomeCategoryCategory, IIncomeCategoriesService incomeCategoryCategoriesService)
    {
        try
        {
            await incomeCategoryCategoriesService.Update(incomeCategoryCategory);
            return Results.Created($"/{incomeCategoryCategory.Id}", incomeCategoryCategory);
        }
        catch
        {
            return Results.BadRequest();
        }

    }

    private static async Task<IResult> Delete(int id, IIncomeCategoriesService incomeCategoryCategoriesService)
    {
        try
        {
            await incomeCategoryCategoriesService.Remove(id);
            return Results.Ok();
        }
        catch
        {
            return Results.BadRequest();
        }
    }
}
