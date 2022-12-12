using Finance.Core.Entities;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;
using Finance.UI.Interfaces;

namespace Finance.UI.Services;

public class ExpenseCategoriesService : IRequestApi<ExpenseCategory>
{
    private readonly FinanceWebApiService _financeWebApiService;

    public ExpenseCategoriesService(FinanceWebApiService financeWebApiService)
    {
        _financeWebApiService = financeWebApiService;
    }

    public async Task Add(ExpenseCategory expenseCategory)
    {
        var expenseCategoryJson = JsonConvert.SerializeObject(expenseCategory);
        var content = new StringContent(expenseCategoryJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PostAsync("expenses/categories", content);
    }

    public async ValueTask<ExpenseCategory?> Find(int id)
    {
        var response = await _financeWebApiService.HttpClient.GetAsync($"expenses/categories/{id}");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<ExpenseCategory>(responseString, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
        }
        catch (Exception)
        {
            return new();
        }
    }

    public async Task<ICollection<ExpenseCategory>> GetAll()
    {
        var response = await _financeWebApiService.HttpClient.GetAsync("expenses/categories");
        var responseString = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<ICollection<ExpenseCategory>>(responseString);
        }
        catch (Exception)
        {
            return new List<ExpenseCategory>();
        }
    }

    public async Task Remove(int id)
    {
        await _financeWebApiService.HttpClient.DeleteAsync($"expenses/categories/{id}");
    }

    public async Task Update(ExpenseCategory expenseCategory)
    {
        var expenseCategoryJson = JsonConvert.SerializeObject(expenseCategory);
        var content = new StringContent(expenseCategoryJson, Encoding.UTF8, "application/json");
        await _financeWebApiService.HttpClient.PutAsync("expenses/categories", content);
    }
}
