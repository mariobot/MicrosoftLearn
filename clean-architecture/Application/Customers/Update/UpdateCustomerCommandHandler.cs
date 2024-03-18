using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Unit>>
{
    private readonly ICustomerRepository customerRepository;
    private readonly IUnitOfWork unitOfWork;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        this.customerRepository = customerRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {   

        if (!await this.customerRepository.ExistAsync(new CustomerId(request.Id)))
        {
            return Error.NotFound("Customer.NotFound","Customer not found");
        }

        if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phonenumber)
        {
            return Error.Validation("Customer.Phonenumber", "Phone number has not correct format");
        }

        if (Address.Create(request.Country, request.Line1, request.Line2, request.City, request.State, request.ZipCode) is not Address address)
        {
            return Error.Validation("Customer.Address", "Address is not valid");
        }

        Customer customer = Customer.UpdateCustomer(request.Id, request.Name, request.LastName, request.Email, phonenumber, address, request.Active);

        this.customerRepository.Update(customer);
        
        await this.unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
