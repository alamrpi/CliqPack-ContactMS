using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactMS.Infrastructure.Persistance
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        protected DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }
        public virtual async Task<T> Add(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<bool> Delete(T entity)
        {
            await Task.CompletedTask;

            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T?> GetById(TId id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            await Task.CompletedTask;

            dbSet.Update(entity);
            return true;
        }
    }
}
