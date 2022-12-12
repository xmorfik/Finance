using Finance.Core.Entities;
using Finance.Repositories.Interfaces;
using Finance.Services.Exceptions;
using Finance.Services.Interfaces;

namespace Finance.Services;

public class ExpensesService : IExpensesService
{
    private readonly IRepository<Expense> _expensesRepository;

    public ExpensesService(IRepository<Expense> expensesRepository)
    {
        _expensesRepository = expensesRepository;
    }

    public async Task Add(Expense expense)
    {
        expense.ExpenseCategory = null;
        await _expensesRepository.AddAsync(expense);
    }

    public async Task Update(Expense expense)
    {
        expense.ExpenseCategory = null;
        await _expensesRepository.UpdateAsync(expense);
    }

    public async Task<ICollection<Expense>> GetAll()
    {
        return await _expensesRepository.ListAsync();
    }

    public async ValueTask<Expense?> Find(int id)
    {
        return await _expensesRepository.GetByIdAsync(id);
    }

    public async Task Remove(int id)
    {
        var expense = await _expensesRepository.GetByIdAsync(id);

        if (expense == null)
        {
            throw new NotFoundException();
        }

        await _expensesRepository.DeleteAsync(expense);
    }
}