using Finance.Core.Entities;

namespace Finance.Services.Interfaces;

public interface IExpensesService
{
    public Task Add(Expense expense);
    public Task Remove(int id);
    public ValueTask<Expense?> Find(int id);
    public Task<ICollection<Expense>> GetAll();
    public Task Update(Expense expense);
}