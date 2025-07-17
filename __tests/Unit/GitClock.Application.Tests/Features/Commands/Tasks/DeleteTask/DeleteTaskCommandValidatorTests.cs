using GitClock.Application.Features.Commands.Tasks.DeleteTask;

namespace GitClock.Application.Tests.Features.Commands.Tasks.DeleteTask
{
    public class DeleteTaskCommandValidatorTests : ValidatorTestBase<DeleteTaskCommand, DeleteTaskCommandValidator>
    {
        [Theory]
        [MemberData(nameof(DeleteTaskData))]
        public override void Should_validate_request(DeleteTaskCommand request, bool isValid)
        {
            Validate(request, isValid);
        }
        public static IEnumerable<object[]> DeleteTaskData =>
        [
            [
                 new DeleteTaskCommand
                 {
                    Id = Guid.Empty,
                 },
                 false
            ],
            [
                 new DeleteTaskCommand
                 {
                    Id = Guid.NewGuid(),
                 },
                 true
            ],
        ];

    }
}