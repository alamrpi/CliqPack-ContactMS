using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Utility.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ContactMS.Application.Contacts.Commands.Update
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ErrorOr<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<bool>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var contact = await _unitOfWork.ContactRepository.GetById(request.Id);
                if(contact == null)
                    return Errors.Common.NotFound;

                contact.Name = request.Name;
                contact.Email = request.Email;
                contact.Address = request.Address;
                contact.PhoneNumber = request.PhoneNumber;

               var result = await _unitOfWork.ContactRepository.Update(contact);

                if (result)
                  await  _unitOfWork.CompleteAsync();

                return result;
			}
			catch (Exception)
			{
				return Errors.Common.InternalServerError;
			}
        }
    }
}
