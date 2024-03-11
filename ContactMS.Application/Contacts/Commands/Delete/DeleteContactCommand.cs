using ErrorOr;
using MediatR;

namespace ContactMS.Application.Contacts.Commands.Update;

public record DeleteContactCommand(Guid Id) : IRequest<ErrorOr<bool>>;
