using Customers.Common;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll;

public record GetAllCustomersQuery() : IRequest<ErrorOr<List<CustomerResponse>>>;