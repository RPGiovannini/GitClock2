using MediatR;

namespace GitClock.Application.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommand : IRequest<CreateTaskCommandResponse>
    {
        public string PersonName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal HourlyRate { get; set; }

    }
}
