using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;

namespace Application.Customers.Create;

internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository customerRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if(PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }

        if(Address.Create(command.Country, command.Line1, command.Line2, command.City, 
            command.State, command.ZipCode) is not Address address)
        {
            throw new ArgumentException(nameof(address));
        }

        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            address,
            true
        );
        
        await customerRepository.Add(customer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}