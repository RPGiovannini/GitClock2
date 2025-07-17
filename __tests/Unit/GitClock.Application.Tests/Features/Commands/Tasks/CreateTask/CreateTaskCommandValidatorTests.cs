using GitClock.Application.Features.Commands.Tasks.CreateTask;

namespace GitClock.Application.Tests.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommandValidatorTests : ValidatorTestBase<CreateTaskCommand, CreateTaskCommandValidator>
    {
        [Theory]
        [MemberData(nameof(CreateTaskData))]
        public override void Should_validate_request(CreateTaskCommand request, bool isValid)
        {
            Validate(request, isValid);
        }
        public static IEnumerable<object[]> CreateTaskData =>
        [
            [
                 new CreateTaskCommand
                 {
                    PersonName = default,
                 },
                 false
            ],          
            [
                 new CreateTaskCommand
                 {
                    PersonName = string.Empty,
                 },
                 false
            ],        
            [
                 new CreateTaskCommand
                 {
                    PersonName = "PersonName",
                 },
                 true
            ],
        ];

    }
}
