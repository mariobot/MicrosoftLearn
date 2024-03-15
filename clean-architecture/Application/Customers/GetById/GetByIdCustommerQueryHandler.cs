using Customers.Common;
using Domain.Customers;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById
{
    internal sealed class GetByIdCustommerQueryHandler : IRequestHandler<GetByIdCustomerQuery, ErrorOr<CustomerResponse>>
    {
        private readonly ICustomerRepository customerRepository;

        public GetByIdCustommerQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<ErrorOr<CustomerResponse>> Handle(GetByIdCustomerQuery query, CancellationToken cancellationToken)
        {
            var customer = await this.customerRepository.GetByIdAsync(new CustomerId(query.Id));

            if (customer == null) 
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
            }

            return new CustomerResponse(
               customer.Id.Value,
               customer.FullName,
               customer.Email,
               customer.PhoneNumber.Value,
               new AddressResponse(customer.Address.Country,
               customer.Address.Line1,
               customer.Address.Line2,
               customer.Address.City,
               customer.Address.State,
               customer.Address.ZipCode),
               customer.Active);
        }
    }
}
