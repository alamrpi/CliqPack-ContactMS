using ContactMS.Domain.Entities;

namespace ContactMS.Application.Interfaces.Repositories
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        Task<IEnumerable<Contact>> GetsAsync(int pageSize, int pageCount, string? searchTerm);
    }
}
