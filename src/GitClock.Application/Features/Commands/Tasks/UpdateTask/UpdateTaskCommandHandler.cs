using FluentValidation;
using GitClock.Application.Features;
using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;

namespace GitClock.Application.Features.Commands.Tasks.UpdateTask;

public class UpdateTaskCommandHandler
    : HandlerBase<UpdateTaskCommand, UpdateTaskCommandResponse>
{
    private readonly IApplicationDbContext _context;

    public UpdateTaskCommandHandler(
        IEnumerable<AbstractValidator<UpdateTaskCommand>> validators,
        IApplicationDbContext context) : base(validators)
    {
        _context = context;
    }

    public override async Task<UpdateTaskCommandResponse> ProcessHandler(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity(request.PersonName, request.Description, request.StartDate, request.EndDate, request.HourlyRate);

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateTaskCommandResponse
        {
            Id = request.Id,
            PersonName = request.PersonName,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            HourlyRate = request.HourlyRate,
            Success = true
        };
    }
}
