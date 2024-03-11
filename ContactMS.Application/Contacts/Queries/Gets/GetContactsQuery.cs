using ContactMS.Contracts.Contact;
using ContactMS.Contracts.QueryParams.Contact;
using ErrorOr;
using MediatR;

namespace ContactMS.Application.Contacts.Queries.Gets;

public record GetContactsQuery(ContactQueryParam queryParams) : IRequest<ErrorOr<IEnumerable<ContactResponse>>>;
