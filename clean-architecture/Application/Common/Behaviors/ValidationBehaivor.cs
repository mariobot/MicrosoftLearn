using System.ComponentModel.DataAnnotations;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Common.Behaivors;

public class ValidationBehaivor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
where TRequest : IRequest<TResponse> where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? validator;

    public ValidationBehaivor(IValidator<TRequest>? validator = null)
    {
        this.validator = validator;
    }
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (this.validator is null)
        {
            return await next();
        }

        var validatorResult = await this.validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.IsValid)
        {
            return await next();
        }

        var errors = validatorResult.Errors
                    .ConvertAll(validationFailure => Error.Validation(
                        validationFailure.PropertyName,
                        validationFailure.ErrorMessage
                    ));

        return (dynamic)errors;
    }
}