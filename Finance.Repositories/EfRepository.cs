using Ardalis.Specification.EntityFrameworkCore;
using Finance.Core.Interfaces;
using Finance.Infrastructure.Data;
using Finance.Repositories.Interfaces;

namespace Finance.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(FinanceDbContext dbContext) : base(dbContext)
    {
    }
}