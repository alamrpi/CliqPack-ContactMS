using ContactMS.Application.Authentication.Common;
using ContactMS.Contracts.Contact;
using ErrorOr;
using MediatR;

namespace ContactMS.Application.Contacts.Commands.Create
{
    public record CreateContactCommand(string Name, string PhoneNumber, string Email, string Address) : IRequest<ErrorOr<ContactResponse>>;

}
