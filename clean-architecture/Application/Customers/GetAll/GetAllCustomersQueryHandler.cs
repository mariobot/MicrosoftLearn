using Customers.Common;
using Domain.Customers;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll;

internal sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ErrorOr<List<CustomerResponse>>>
{
    private readonly ICustomerRepository customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<ErrorOr<List<CustomerResponse>>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
    {
        var customers = await this.customerRepository.GetAllAsync();

        if (customers is null)
        {
            return Error.NotFound("Not exist data");
        }

        return customers.Select(customer => new CustomerResponse(
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
                   customer.Active
           )).ToList();
    }
}
