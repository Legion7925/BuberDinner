using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using BubberDinner.Domain.Common.Errors;
using MediatR;
using BubberDinner.Domain.Entities;
using BubberDinner.Application.Authentication.Common;

namespace BubberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        //get rid of the async warning
        await Task.CompletedTask;

        //check if user already exists
        if (userRepository.GetUserByEmail(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        //create a user 
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            Email = request.Email
        };
        userRepository.Add(user);
        //create jwt token 

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
