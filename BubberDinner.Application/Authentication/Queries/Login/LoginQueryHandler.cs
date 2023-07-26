using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using BubberDinner.Application.Authentication.Common;

namespace BubberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }


    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        //get rid of the async warning
        await Task.CompletedTask;

        //validate user if he exists
        if (userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredintials;
        }
        //validate the password
        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredintials;
        }
        //create JWT token 
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user,
            token);
    }
}
