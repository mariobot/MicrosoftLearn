using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

public record class DeleteCustomerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;