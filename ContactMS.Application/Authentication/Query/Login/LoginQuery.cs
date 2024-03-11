
using ContactMS.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ContactMS.Application.Authentication.Query.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
