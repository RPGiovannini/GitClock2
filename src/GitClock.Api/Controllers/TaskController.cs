using Microsoft.AspNetCore.Mvc;
using MediatR;
using GitClock.Application.Features.Commands.Tasks.CreateTask;
using GitClock.Application.Features.Commands.Tasks.UpdateTask;

namespace GitClock.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TaskController> _logger;

    public TaskController(IMediator mediator, ILogger<TaskController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateTaskCommandResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CreateTaskCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateTaskCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTaskCommand request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}