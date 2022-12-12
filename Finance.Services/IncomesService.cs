using Finance.Core.Entities;
using Finance.Repositories.Interfaces;
using Finance.Services.Exceptions;
using Finance.Services.Interfaces;

namespace Finance.Services;

public class IncomesService : IIncomesService
{
    private readonly IRepository<Income> _incomesRepository;

    public IncomesService(IRepository<Income> incomesRepository)
    {
        _incomesRepository = incomesRepository;
    }

    public async Task Add(Income income)
    {
        income.IncomeCategory = null;
        await _incomesRepository.AddAsync(income);
    }

    public async Task Update(Income income)
    {
        income.IncomeCategory = null;
        await _incomesRepository.UpdateAsync(income);
    }

    public async Task<ICollection<Income>> GetAll()
    {
        return await _incomesRepository.ListAsync();
    }

    public async ValueTask<Income?> Find(int id)
    {
        return await _incomesRepository.GetByIdAsync(id);
    }

    public async Task Remove(int id)
    {
        var income = await _incomesRepository.GetByIdAsync(id);

        if (income == null)
        {
            throw new NotFoundException();
        }

        await _incomesRepository.DeleteAsync(income);
    }
}