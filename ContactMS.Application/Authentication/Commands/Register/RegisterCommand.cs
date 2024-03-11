using ContactMS.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ContactMS.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Name, string PhoneNumber, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
