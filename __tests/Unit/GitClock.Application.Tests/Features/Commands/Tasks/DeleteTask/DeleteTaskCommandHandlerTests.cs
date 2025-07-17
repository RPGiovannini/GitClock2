using System.IO;
using GitClock.Application.Features.Commands.Tasks.DeleteTask;
using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitClock.Application.Tests.Features.Commands.Tasks.DeleteTask
{
    public class DeleteTaskCommandHandlerTests : HandlerTestBase<DeleteTaskCommand, DeleteTaskCommandHandler, DeleteTaskCommandResponse>
    {
        private IApplicationDbContext Context => GetParam<IApplicationDbContext>();
        private DeleteTaskCommand defaultDeleteTaskCommand;
        public DeleteTaskCommandHandlerTests()
        {
            defaultDeleteTaskCommand = Builder<DeleteTaskCommand>
                .CreateNew()
                .Build();
        }
        [Fact]
        public void DeleteTaskCommandHandler_ShouldDeleteTask_WhenInValidCommand()
        {
            var response = CallHandler(defaultDeleteTaskCommand);

            response.Success.ShouldBeTrue();

            Context.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}