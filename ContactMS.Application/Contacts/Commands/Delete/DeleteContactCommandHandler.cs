using ContactMS.Application.Interfaces.Repositories;
using ContactMS.Utility.Errors;
using ErrorOr;

using MediatR;

namespace ContactMS.Application.Contacts.Commands.Update
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ErrorOr<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var contact = await _unitOfWork.ContactRepository.GetById(request.Id);
                if(contact == null)
                    return Errors.Common.NotFound;

               var result = await _unitOfWork.ContactRepository.Delete(contact);

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
