using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

record class DeleteCustomerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;