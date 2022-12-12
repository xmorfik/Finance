using Finance.Core.Entities;
using Finance.UI.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;

namespace Finance.UI.Services;

public class ExpensesService : IRequestApi<Expense>
{
    private readonly FinanceWebApiService _financeWebApiService;

    public ExpensesService(FinanceWebApiService financeWebApiService)
    {
        _financeWebApiService = financeWebApiService;
    }

    public async Task Add(Expense expense)
    {
        var expenseJson = JsonConvert.SerializeObject(expense);
        var content = new StringContent(expenseJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PostAsync("expenses", content);
    }

    public async ValueTask<Expense?> Find(int id)
    {
        var response = await _financeWebApiService.HttpClient.GetAsync($"expenses/{id}");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<Expense>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            return new();
        }
    }

    public async Task<ICollection<Expense>> GetAll()
    {
        var response = await _financeWebApiService.HttpClient.GetAsync("expenses");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<ICollection<Expense>>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            return new List<Expense>();
        }
    }

    public async Task Remove(int id)
    {
        await _financeWebApiService.HttpClient.DeleteAsync($"expenses/{id}");
    }

    public async Task Update(Expense expense)
    {
        var expenseJson = JsonConvert.SerializeObject(expense);
        var content = new StringContent(expenseJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PutAsync("expenses", content);
    }
}
