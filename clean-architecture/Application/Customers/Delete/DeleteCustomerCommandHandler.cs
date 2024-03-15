using Domain.Customers;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Customers.Delete
{
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await this.customerRepository.GetByIdAsync(new CustomerId(request.Id)) is not Customer customer)
            {
                return Error.Validation("Customer.Delete", "The customer not exist");
            }
            
            this.customerRepository.Delete(customer);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
