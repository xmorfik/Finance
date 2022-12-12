using Finance.Core.Entities;
using Finance.UI.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Finance.UI.Services;

public class IncomesService : IRequestApi<Income>
{
    private readonly FinanceWebApiService _financeWebApiService;

    public IncomesService(FinanceWebApiService financeWebApiService)
    {
        _financeWebApiService = financeWebApiService;
    }

    public async Task Add(Income income)
    {
        var incomeJson = JsonConvert.SerializeObject(income);
        var content = new StringContent(incomeJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PostAsync("incomes", content);
    }

    public async ValueTask<Income?> Find(int id)
    {
        var response = await _financeWebApiService.HttpClient.GetAsync($"incomes/{id}");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<Income>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            return new();
        }
    }

    public async Task<ICollection<Income>> GetAll()
    {
        var response = await _financeWebApiService.HttpClient.GetAsync("incomes");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<ICollection<Income>>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            return new List<Income>();
        }
    }

    public async Task Remove(int id)
    {
        await _financeWebApiService.HttpClient.DeleteAsync($"incomes/{id}");
    }

    public async Task Update(Income income)
    {
        var incomeJson = JsonConvert.SerializeObject(income);
        var content = new StringContent(incomeJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PutAsync("incomes", content);
    }
}
