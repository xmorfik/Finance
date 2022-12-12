using Finance.Core.Entities;
using Finance.UI.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;

namespace Finance.UI.Services;

public class IncomeCategoriesService : IRequestApi<IncomeCategory>
{
    private readonly FinanceWebApiService _financeWebApiService;

    public IncomeCategoriesService(FinanceWebApiService financeWebApiService)
    {
        _financeWebApiService = financeWebApiService;
    }

    public async Task Add(IncomeCategory incomeCategory)
    {
        var incomeCategoryJson = JsonConvert.SerializeObject(incomeCategory);
        var content = new StringContent(incomeCategoryJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PostAsync("incomes/categories", content);
    }

    public async ValueTask<IncomeCategory?> Find(int id)
    {
        var response = await _financeWebApiService.HttpClient.GetAsync($"incomes/categories/{id}");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<IncomeCategory>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            return new();
        }
    }

    public async Task<ICollection<IncomeCategory>> GetAll()
    {
        var response = await _financeWebApiService.HttpClient.GetAsync("incomes/categories");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<ICollection<IncomeCategory>>(responseString);
        }
        catch (Exception)
        {
            return new List<IncomeCategory>();
        }
    }

    public async Task Remove(int id)
    {
        await _financeWebApiService.HttpClient.DeleteAsync($"incomes/categories/{id}");
    }

    public async Task Update(IncomeCategory incomeCategory)
    {
        var incomeCategoryJson = JsonConvert.SerializeObject(incomeCategory);
        var content = new StringContent(incomeCategoryJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PutAsync("incomes/categories", content);
    }
}
