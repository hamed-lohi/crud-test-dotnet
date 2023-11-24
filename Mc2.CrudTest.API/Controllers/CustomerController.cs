using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CustomerController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomerQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get([FromQuery] SearchCustomerQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return result is null ? NotFound() : Ok(result); ;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateCustomerCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Delete([FromBody] RemoveCustomerCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}
