using FluentValidation;
using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;

namespace GitClock.Application.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommandHandler
        : HandlerBase<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaskCommandHandler(
            IEnumerable<AbstractValidator<CreateTaskCommand>> validators,
            IApplicationDbContext context) : base(validators)
        {
            _context = context;
        }

        public override async Task<CreateTaskCommandResponse> ProcessHandler(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskEntity(request.PersonName, request.Description, request.StartDate, request.EndDate, request.HourlyRate);

            await _context.Tasks.AddAsync(task, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateTaskCommandResponse { Id = task.Id };
        }
    }
}