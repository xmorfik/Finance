using Finance.Core.Entities;
using Finance.Repositories.Interfaces;
using Finance.Repositories.Specifications;
using Finance.Services.Exceptions;
using Finance.Services.Interfaces;

namespace Finance.Services;

public class ExpenseCategoriesService : IExpenseCategoriesService
{
    private readonly IRepository<ExpenseCategory> _expenseCategoriesRepository;
    private readonly IRepository<Expense> _expensesRepository;

    public ExpenseCategoriesService(
        IRepository<ExpenseCategory> expenseCategoriesRepository,
        IRepository<Expense> expensesRepository)
    {
        _expensesRepository = expensesRepository;
        _expenseCategoriesRepository = expenseCategoriesRepository;
    }

    public async Task Add(ExpenseCategory expenseCategory)
    {
        await _expenseCategoriesRepository.AddAsync(expenseCategory);
    }

    public async Task Update(ExpenseCategory expenseCategory)
    {
        await _expenseCategoriesRepository.UpdateAsync(expenseCategory);
    }

    public async Task<ICollection<ExpenseCategory>> GetAll()
    {
        return await _expenseCategoriesRepository.ListAsync();
    }

    public async ValueTask<ExpenseCategory?> Find(int id)
    {
        return await _expenseCategoriesRepository.GetByIdAsync(id);
    }

    public async Task Remove(int id)
    {
        var expenseCategory = await _expenseCategoriesRepository.GetByIdAsync(id);

        if (expenseCategory == null || expenseCategory.Id == null)
        {
            throw new NotFoundException();
        }

        var expenses = await _expensesRepository.ListAsync(new ExpenseByCategoryId((int)expenseCategory.Id));

        if (expenses.Count > 0)
        {
            throw new LinkToAnotherTableException("Link to another table");
        }

        await _expenseCategoriesRepository.DeleteAsync(expenseCategory);
    }
}