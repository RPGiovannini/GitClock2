using FluentValidation;
using GitClock.Application.Features;
using GitClock.Domain.Interfaces;

namespace GitClock.Application.Features.Commands.Tasks.DeleteTask;

public class DeleteTaskCommandHandler
    : HandlerBase<DeleteTaskCommand, DeleteTaskCommandResponse>
{
    private readonly IApplicationDbContext _context;

    public DeleteTaskCommandHandler(
        IEnumerable<AbstractValidator<DeleteTaskCommand>> validators,
        IApplicationDbContext context) : base(validators)
    {
        _context = context;
    }

    public override async Task<DeleteTaskCommandResponse> ProcessHandler(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FindAsync(request.Id);
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);

        return new DeleteTaskCommandResponse
        {
            Id = request.Id,
            Success = true
        };
    }
}
