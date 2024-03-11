using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Contracts.Contact;
using ContactMS.Utility.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ContactMS.Application.Contacts.Queries.GetById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ErrorOr<ContactResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ContactResponse>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _unitOfWork.ContactRepository.GetById(request.Id);
                if (contact == null)
                    return Error.Validation("contact.notfound", "Contact information not found!");

                return _mapper.Map<ContactResponse>(contact);
            }
            catch (Exception)
            {
                return Errors.Common.InternalServerError;
            }
        }
    }
}
