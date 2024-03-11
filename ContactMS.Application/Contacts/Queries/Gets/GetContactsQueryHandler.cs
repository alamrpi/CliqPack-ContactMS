using ContactMS.Application.Contacts.Queries.GetById;
using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Contracts.Contact;
using ContactMS.Utility.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ContactMS.Application.Contacts.Queries.Gets
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, ErrorOr<IEnumerable<ContactResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContactsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<IEnumerable<ContactResponse>>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _unitOfWork.ContactRepository.GetsAsync(request.queryParams.PageSize, request.queryParams.PageCount, request.queryParams.SearchTerm);
                if (contact == null)
                    return Error.Validation("contact.notfound", "Contact information not found!");

                return _mapper.Map<IEnumerable<ContactResponse>>(contact).ToList();
            }
            catch (Exception)
            {
                return Errors.Common.InternalServerError;
            }
        }
    }
}
