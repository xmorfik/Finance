using Finance.Core.Entities;
using Finance.Services.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Finance.UI.Services;

public class ReportService : IReportService
{
    private readonly FinanceWebApiService _financeWebApiService;

    public ReportService(FinanceWebApiService financeWebApiService)
    {
        _financeWebApiService = financeWebApiService;
    }

    public async ValueTask<Report?> GetAllReport()
    {
        var response = await _financeWebApiService.HttpClient.GetAsync("reports/all");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<Report>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async ValueTask<Report?> GetDailyReport(DateOnly date)
    {
        var response = await _financeWebApiService.HttpClient.GetAsync($"reports/{date.ToString("dd.MM.yyyy")}");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<Report>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async ValueTask<Report?> GetPeriodReport(DateOnly dateStart, DateOnly dateEnd)
    {
        var response = await _financeWebApiService.HttpClient.GetAsync($"reports/{dateStart.ToString("dd.MM.yyyy")}/{dateEnd.ToString("dd.MM.yyyy")}");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<Report>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            throw;
        }
    }
}
