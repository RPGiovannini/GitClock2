using System.IO;
using GitClock.Application.Features.Commands.Tasks.UpdateTask;
using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitClock.Application.Tests.Features.Commands.Tasks.UpdateTask
{
    public class UpdateTaskCommandHandlerTests : HandlerTestBase<UpdateTaskCommand, UpdateTaskCommandHandler, UpdateTaskCommandResponse>
    {
        private IApplicationDbContext Context => GetParam<IApplicationDbContext>();
        private UpdateTaskCommand defaultUpdateTaskCommand;
        public UpdateTaskCommandHandlerTests()
        {
            defaultUpdateTaskCommand = Builder<UpdateTaskCommand>
                .CreateNew()
                .With(c => c.HourlyRate = 50)
                .Build();
        }
        [Fact]
        public void UpdateTaskCommandHandler_ShouldUpdateTask_WhenInValidCommand()
        {
            var response = CallHandler(defaultUpdateTaskCommand);

            response.Success.ShouldBeTrue();

            Context.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}