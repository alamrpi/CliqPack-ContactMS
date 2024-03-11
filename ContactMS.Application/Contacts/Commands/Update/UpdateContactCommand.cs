using ErrorOr;
using MediatR;

namespace ContactMS.Application.Contacts.Commands.Update
{
    public record UpdateContactCommand(Guid Id, string Name, string PhoneNumber, string Email, string Address) : IRequest<ErrorOr<bool>>
    {
    }

}
