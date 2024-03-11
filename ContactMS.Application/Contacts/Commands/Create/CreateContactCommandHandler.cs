using ContactMS.Application.Contacts.Commands.Update;
using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Contracts.Contact;
using ContactMS.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ContactMS.Application.Contacts.Commands.Create
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ErrorOr<ContactResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<ContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact>(request);
            contact.Id = Contact.MakeId();

            var result = await _unitOfWork.ContactRepository.Add(contact);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ContactResponse>(result);
        }
    }
}
