using ContactMS.Domain.Entities;

namespace ContactMS.Application.Authentication.Common
{
    public record AuthenticationResult(ApplicationUser User, string Token);
}
