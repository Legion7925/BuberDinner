using ErrorOr;
using FluentValidation;
using MediatR;

namespace BubberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest , TResponse> : IPipelineBehavior<TRequest , TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? validator;

    public ValidationBehavior(IValidator<TRequest>? Validator = null)
    {
        validator = Validator;
    }
    public async Task<TResponse > Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(validator is null)
            return await next();

        var validateResult = await validator.ValidateAsync(request, cancellationToken);

        if (validateResult.IsValid)
           return await next();

        var errors = validateResult.Errors
            .ConvertAll(validateionFailure => Error.Validation(
                validateionFailure.PropertyName ,
                validateionFailure.ErrorMessage));

        return (dynamic)errors;
    }
}
