using MediatR;

namespace GitClock.Application.Features.Commands.Tasks.UpdateTask;

public class UpdateTaskCommand : IRequest<UpdateTaskCommandResponse>
{
    public Guid Id { get; set; }
    public string PersonName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal HourlyRate { get; set; }
}
