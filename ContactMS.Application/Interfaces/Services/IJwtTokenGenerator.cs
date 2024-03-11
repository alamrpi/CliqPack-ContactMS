using ContactMS.Domain.Entities;

namespace ContactMS.Application.Interfaces.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
