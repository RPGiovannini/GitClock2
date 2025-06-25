using FluentValidation;

namespace GitClock.Application.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(p => p.PersonName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
