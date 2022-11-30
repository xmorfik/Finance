using Finance.Core.Entities;
using Finance.Services.Interfaces;
using Finance.WebApi.Helpers;

namespace Finance.WebApi.Apis.Endpoints;

public static class ReportsEndpoints
{
    public static RouteGroupBuilder MapReportsEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetDailyReport)
                 .WithTags("Getters")
                 .WithOpenApi();

        group.MapGet("/{date}", GetReport)
                 .WithTags("Getters")
                 .WithOpenApi();

        group.MapGet("/{start}/{end}", GetPeriodReport)
                .WithTags("Getters")
                .WithOpenApi();

        return group;
    }

    private static async Task<IResult> GetDailyReport(IReportService reportService)
    {
        return await reportService.GetDailyReport(DateOnly.FromDateTime(DateTime.Today)) is Report report
        ? Results.Ok(report)
        : Results.NotFound();
    }

    private static async Task<IResult> GetReport(DateBinder date, IReportService reportService)
    {
        return await reportService.GetDailyReport(date.Date) is Report report
        ? Results.Ok(report)
        : Results.NotFound();
    }

    private static async Task<IResult> GetPeriodReport(DateBinder start, DateBinder end, IReportService reportService)
    {
        return await reportService.GetPeriodReport(start.Date, end.Date) is Report report
        ? Results.Ok(report)
        : Results.NotFound();
    }
}
