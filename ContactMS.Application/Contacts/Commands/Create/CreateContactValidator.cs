using ContactMS.Application.Contacts.Commands.Update;
using FluentValidation;

namespace ContactMS.Application.Contacts.Commands.Create
{
    public class CreateContactValidator : AbstractValidator<UpdateContactCommand>
    {
        public CreateContactValidator()
        {
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
