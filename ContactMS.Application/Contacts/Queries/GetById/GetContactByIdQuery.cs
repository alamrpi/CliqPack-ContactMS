using ContactMS.Contracts.Contact;
using ErrorOr;
using MediatR;

namespace ContactMS.Application.Contacts.Queries.GetById;

public record GetContactByIdQuery(Guid Id) : IRequest<ErrorOr<ContactResponse>>;
