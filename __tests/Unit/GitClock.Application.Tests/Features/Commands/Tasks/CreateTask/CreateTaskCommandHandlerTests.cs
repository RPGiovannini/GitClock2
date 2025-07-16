using System.IO;
using GitClock.Application.Features.Commands.Tasks.CreateTask;
using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitClock.Application.Tests.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommandHandlerTests : HandlerTestBase<CreateTaskCommand, CreateTaskCommandHandler, CreateTaskCommandResponse>
    {
        private IApplicationDbContext Context => GetParam<IApplicationDbContext>();
        private CreateTaskCommand defaultCreateTaskCommand;
        public CreateTaskCommandHandlerTests()
        {
            defaultCreateTaskCommand = Builder<CreateTaskCommand>
                .CreateNew()
                .With(c => c.HourlyRate = 50)
                .Build();
        }
        [Fact]
        public void CreateTaskCommandHandler_ShouldCreateTask_WhenInValidCommand()
        {
            var response = CallHandler(defaultCreateTaskCommand);

            response.Id.ShouldNotBe(Guid.Empty);

            Context.Tasks.Received(1).AddAsync(Arg.Any<TaskEntity>(), Arg.Any<CancellationToken>());

            Context.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}