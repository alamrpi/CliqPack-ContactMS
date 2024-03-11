using ErrorOr;
using MediatR;
using ContactMS.Application.Authentication.Commands.Register;
using ContactMS.Application.Authentication.Common;
using ContactMS.Application.Interfaces.Services;
using ContactMS.Utility.Errors;
using ContactMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager)
        {
            this._jwtTokenGenerator = jwtTokenGenerator;
            this._userManager = userManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var userFromDb = await _userManager.FindByEmailAsync(command.Email);

            if (userFromDb is not null)
                return Errors.User.DuplicateEmail;

            //Create JWT token
            var user = new ApplicationUser
            {
                Name = command.Name,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                NormalizedEmail = command.Email.ToUpper(),
                UserName = command.Email,
                NormalizedUserName = command.Email.ToUpper()
            };

            await _userManager.CreateAsync(user, command.Password);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
