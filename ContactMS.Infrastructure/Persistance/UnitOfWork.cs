using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Infrastructure.Data;

namespace ContactMS.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IContactRepository ContactRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            ContactRepository = new ContactRepository(context);
        }

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
