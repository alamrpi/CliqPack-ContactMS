using ContactMS.Application.Authentication.Commands.Register;
using ContactMS.Application.Authentication.Query.Login;
using ContactMS.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactMS.Api.Controllers
{
    [Route("[controller]")]
    public class AuthenticationController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public AuthenticationController(IMapper mapper, ISender sender)
        {
            this._mapper = mapper;
            this._sender = sender;
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var result = await _sender.Send(command);

            return result.Match(
                    authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                    Problem
                );
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var result = await _sender.Send(query);
            return result.Match(
                   authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                  errors => Problem(errors)
               );
        }
    }
}
