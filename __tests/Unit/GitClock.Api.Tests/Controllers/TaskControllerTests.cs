using GitClock.Application.Features.Commands.Tasks.UpdateTask;

namespace GitClock.Api.Tests.Controllers
{
    public class TaskControllerTests : ControllerTestBase<TaskController>
    {
        [Fact]
        public async Task Should_call_post_method()
        {
            var request = Builder<CreateTaskCommand>
                .CreateNew()
                .Build();

            var response = await controller.Post(request);

            await mediator.Received().Send(Arg.Any<CreateTaskCommand>());

            response.ShouldBeOfType<OkObjectResult>();
        }
        [Fact]
        public async Task Should_call_put_method()
        {
            var id = Guid.NewGuid();
            var request = Builder<UpdateTaskCommand>
                .CreateNew()
                .Build();

            var response = await controller.Put(id, request);

            await mediator.Received().Send(Arg.Any<UpdateTaskCommand>());

            response.ShouldBeOfType<OkObjectResult>();
        }
    }
}
