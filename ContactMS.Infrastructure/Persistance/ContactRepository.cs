using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Domain.Entities;
using ContactMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactMS.Infrastructure.Persistance
{
    public class ContactRepository : Repository<Contact, Guid>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Contact>> GetsAsync(int pageSize, int pageCount, string? searchTerm)
        {
            var qeury =  _dbContext.Contacts.AsQueryable();
            if(!string.IsNullOrWhiteSpace(searchTerm))
                qeury = qeury.Where(x => x.Name.Contains(searchTerm!) || x.Email.Contains(searchTerm!) || x.Address.Contains(searchTerm!) || x.PhoneNumber.Contains(searchTerm!));
            return await qeury.Take(pageCount).Skip((pageSize - 1) * pageCount).ToListAsync();
        }
    }
}
