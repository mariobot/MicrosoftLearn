using Application.Customers.Create;
using Application.Customers.Delete;
using Application.Customers.GetAll;
using Application.Customers.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("customers")]
public class Customers : ApiController
{
    private readonly ISender mediator;

    public Customers(ISender mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getByIdCustomerResult = await this.mediator.Send(new GetByIdCustomerQuery(id));

        return getByIdCustomerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
            );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allCustomersResult = await this.mediator.Send(new GetAllCustomersQuery());

        return allCustomersResult.Match(
            customers => Ok(customers),
            errors => Problem(errors)
            );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createCustomerResult = await this.mediator.Send(command);

        return createCustomerResult.Match(
            customer => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteCustomerResult = await this.mediator.Send(new DeleteCustomerCommand(id));

        return deleteCustomerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
            );
    }
}