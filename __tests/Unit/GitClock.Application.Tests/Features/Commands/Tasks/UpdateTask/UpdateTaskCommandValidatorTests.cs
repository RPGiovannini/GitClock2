using GitClock.Application.Features.Commands.Tasks.UpdateTask;

namespace GitClock.Application.Tests.Features.Commands.Tasks.UpdateTask
{
    public class UpdateTaskCommandValidatorTests : ValidatorTestBase<UpdateTaskCommand, UpdateTaskCommandValidator>
    {
        [Theory]
        [MemberData(nameof(UpdateTaskData))]
        public override void Should_validate_request(UpdateTaskCommand request, bool isValid)
        {
            Validate(request, isValid);
        }
        public static IEnumerable<object[]> UpdateTaskData =>
        [
            [
                 new UpdateTaskCommand
                 {
                    Id = Guid.Empty,
                 },
                 false
            ],
            [
                 new UpdateTaskCommand
                 {
                    PersonName = default,
                 },
                 false
            ],
            [
                 new UpdateTaskCommand
                 {
                    PersonName = string.Empty,
                 },
                 false
            ],
            [
                 new UpdateTaskCommand
                 {
                    Id = Guid.NewGuid(),
                    PersonName = "PersonName",
                 },
                 true
            ],
        ];

    }
}