using ErrorOr;
using MediatR;
using ContactMS.Application.Authentication.Common;
using ContactMS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using ContactMS.Domain.Entities;
using ContactMS.Utility.Errors;

namespace ContactMS.Application.Authentication.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            this._userManager = userManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);

            if (user is null)
                return Errors.Authentication.InvalidCredentials;

            if (!await _userManager.CheckPasswordAsync(user, query.Password))
                return Errors.Authentication.InvalidCredentials;

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
