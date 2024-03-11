using ContactMS.Application.Authentication.Commands.Register;
using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
           
            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
