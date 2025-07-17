using MediatR;

namespace GitClock.Application.Features.Commands.Tasks.DeleteTask;

public class DeleteTaskCommand : IRequest<DeleteTaskCommandResponse>
{
    public Guid Id { get; set; }
}
