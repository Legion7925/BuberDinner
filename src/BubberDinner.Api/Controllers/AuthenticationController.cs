using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contracts.Authentication;
using BubberDinner.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender mediator;
        private readonly IMapper mapper;

        public AuthenticationController(IMediator mediator , IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = mapper.Map<RegisterCommand>(request);
            var authResult = await mediator.Send(command);

            return authResult.Match(
                result => Ok(mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginResult = await mediator.Send(mapper.Map<LoginQuery>(request));
            if(loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredintials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized,
                               title: loginResult.FirstError.Description); 
            }
            return loginResult.Match(
                result => Ok(mapper.Map<AuthenticationResponse>(result)),
                Problem);
        }
    }
}
