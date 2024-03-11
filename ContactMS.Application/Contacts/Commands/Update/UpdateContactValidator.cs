using FluentValidation;

namespace ContactMS.Application.Contacts.Commands.Update
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name)
               .NotEmpty()
               .MaximumLength(255);

            RuleFor(x => x.Email)
              .NotEmpty()
              .EmailAddress();

            RuleFor(x => x.PhoneNumber)
            .NotEmpty();

            RuleFor(x => x.Address)
          .NotEmpty();

        }
    }
}
