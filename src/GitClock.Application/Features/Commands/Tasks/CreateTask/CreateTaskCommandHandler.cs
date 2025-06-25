using System.Runtime.InteropServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GitClock.Application.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommandHandler
        : HandlerBase<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IEnumerable<AbstractValidator<CreateTaskCommand>> _validators;
        public CreateTaskCommandHandler(IEnumerable<AbstractValidator<CreateTaskCommand>> validators) : base(validators)
        {
            _validators = validators;
        }
        public override Task<CreateTaskCommandResponse> ProcessHandler(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
[Route("api/v1/price-types")]
public class PriceTypesController(IMediator mediator) : PocMediatRController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CreatePriceTypeCommand request)
    {
        await mediator.Send(request);
        return Created();
    }
}

public static class MediatorConfiguration
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(HandlerBase<,>).Assembly));
        return services;
    }
}