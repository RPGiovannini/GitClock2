using FluentValidation;

namespace GitClock.Application.Features.Commands.Tasks.DeleteTask;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty();
    }
}
