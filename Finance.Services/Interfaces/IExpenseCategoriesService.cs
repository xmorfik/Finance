using Finance.Core.Entities;

namespace Finance.Services.Interfaces;

public interface IExpenseCategoriesService
{
    public Task Add(ExpenseCategory expenseCategory);
    public Task Remove(int id);
    public ValueTask<ExpenseCategory?> Find(int id);
    public Task<ICollection<ExpenseCategory>> GetAll();
    public Task Update(ExpenseCategory expenseCategory);
}