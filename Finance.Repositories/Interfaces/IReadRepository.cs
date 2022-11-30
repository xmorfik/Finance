using Ardalis.Specification;
using Finance.Core.Interfaces;

namespace Finance.Repositories.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
