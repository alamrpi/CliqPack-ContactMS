namespace ContactMS.Application.Interfaces.Repositories
{
    public interface IRepository<T, TId>
    {
        Task<IEnumerable<T>> All();
        Task<T?> GetById(TId id);
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
