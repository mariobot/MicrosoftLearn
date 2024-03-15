using FluentValidation;

namespace Application.Customers.Delete
{
    internal class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator() 
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
