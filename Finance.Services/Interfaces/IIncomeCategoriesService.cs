using Finance.Core.Entities;

namespace Finance.Services.Interfaces;

public interface IIncomeCategoriesService
{
    public Task Add(IncomeCategory incomeCategory);
    public Task Remove(int id);
    public ValueTask<IncomeCategory?> Find(int id);
    public Task<ICollection<IncomeCategory>> GetAll();
    public Task Update(IncomeCategory incomeCategory);
}