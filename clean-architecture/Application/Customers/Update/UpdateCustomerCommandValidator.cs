using FluentValidation;

namespace Application.Customers.Update;

internal class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty();
        RuleFor(r => r.Name).NotEmpty().MaximumLength(50);
        RuleFor(r => r.LastName).NotEmpty().MaximumLength(50);
        RuleFor(r => r.Email).NotEmpty().EmailAddress().MaximumLength(255);
        RuleFor(r => r.PhoneNumber).NotEmpty().MaximumLength(9);
        RuleFor(r => r.Country).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Line1).NotEmpty().MaximumLength(20);
        RuleFor(r => r.Line2).NotEmpty().MaximumLength(20);
        RuleFor(r => r.City).NotEmpty().MaximumLength(40);
        RuleFor(r => r.State).NotEmpty().MaximumLength(40);
        RuleFor(r => r.ZipCode).NotEmpty().MaximumLength(10);
    }
}
