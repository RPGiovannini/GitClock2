using FluentValidation;

namespace GitClock.Application.Features.Commands.Tasks.UpdateTask;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty();

        RuleFor(p => p.PersonName)
            .NotEmpty()
            .MaximumLength(50);
    }
}
