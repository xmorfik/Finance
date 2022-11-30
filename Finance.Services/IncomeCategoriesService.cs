using Finance.Core.Entities;
using Finance.Repositories.Interfaces;
using Finance.Repositories.Specifications;
using Finance.Services.Exceptions;
using Finance.Services.Interfaces;

namespace Finance.Services;

public class IncomeCategoriesService : IIncomeCategoriesService
{
    private readonly IRepository<IncomeCategory> _incomeCategoriesRepository;
    private readonly IRepository<Income> _incomesRepository;

    public IncomeCategoriesService(
        IRepository<IncomeCategory> incomeCategoriesRepository,
        IRepository<Income> incomesRepository)
    {
        _incomesRepository= incomesRepository;
        _incomeCategoriesRepository = incomeCategoriesRepository;
    }

    public async Task Add(IncomeCategory incomeCategory)
    {
        await _incomeCategoriesRepository.AddAsync(incomeCategory);
    }

    public async Task Update(IncomeCategory incomeCategory)
    {
        await _incomeCategoriesRepository.UpdateAsync(incomeCategory);
    }

    public async Task<ICollection<IncomeCategory>> GetAll()
    {
        return await _incomeCategoriesRepository.ListAsync();
    }

    public async ValueTask<IncomeCategory?> Find(int id)
    {
        return await _incomeCategoriesRepository.GetByIdAsync(id);
    }

    public async Task Remove(int id)
    {
        var incomeCategory = await _incomeCategoriesRepository.GetByIdAsync(id);

        if (incomeCategory == null || incomeCategory.Id == null)
        {
            throw new NotFoundException();
        }

        var incomes = await _incomesRepository.ListAsync(new IncomeByCategoryId((int)incomeCategory.Id));

        if(incomes.Count > 0)
        {
            throw new LinkToAnotherTableException("Link to another table");
        }

        await _incomeCategoriesRepository.DeleteAsync(incomeCategory);
    }
}