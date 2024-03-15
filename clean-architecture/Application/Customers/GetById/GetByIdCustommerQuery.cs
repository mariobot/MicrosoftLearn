using Customers.Common;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;

public record GetByIdCustomerQuery(
    Guid Id) : IRequest<ErrorOr<CustomerResponse>>;