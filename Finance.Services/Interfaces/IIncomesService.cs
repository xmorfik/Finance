using Finance.Core.Entities;

namespace Finance.Services.Interfaces;

public interface IIncomesService
{
    public Task Add(Income income);
    public Task Remove(int id);
    public ValueTask<Income?> Find(int id);
    public Task<ICollection<Income>> GetAll();
    public Task Update(Income income);
}