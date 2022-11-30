using Ardalis.Specification;
using Finance.Core.Interfaces;

namespace Finance.Repositories.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
