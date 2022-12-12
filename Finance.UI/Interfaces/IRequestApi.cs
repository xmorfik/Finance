using Finance.Core.Interfaces;

namespace Finance.UI.Interfaces;

public interface IRequestApi<T> where T : class, IAggregateRoot
{
    public Task Add(T item);
    public Task Remove(int id);
    public ValueTask<T?> Find(int id);
    public Task<ICollection<T>> GetAll();
    public Task Update(T item);
}
