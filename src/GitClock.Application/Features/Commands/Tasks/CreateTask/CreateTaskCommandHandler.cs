using System.Runtime.InteropServices;
using FluentValidation;
using GitClock.Domain.Entities;
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
        public override async Task<CreateTaskCommandResponse> ProcessHandler(CreateTaskCommand request, CancellationToken cancellationToken)
        { 
            var task = new TaskEntity(request.PersonName, request.Description, request.StartDate, request.EndDate, request.HourlyRate);
            return new CreateTaskCommandResponse { Id = task.Id};

        }
    }
}