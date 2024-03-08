using Application.Customers.Create;
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createCustomerResult = await this.mediator.Send(command);

        return createCustomerResult.Match(
            customer => Ok(),
            errors => Problem(errors)
        );
    }
}