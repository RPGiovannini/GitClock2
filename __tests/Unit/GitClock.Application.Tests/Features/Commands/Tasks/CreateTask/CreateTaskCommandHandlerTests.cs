using FluentValidation;
using GitClock.Application.Features.Commands.Tasks.CreateTask;
using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;
using NSubstitute;

namespace GitClock.Application.Tests.Features.Commands.Tasks.CreateTask
{
    public class CreateTaskCommandHandlerTests : HandlerTestBase<CreateTaskCommandHandler, CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaskCommandHandlerTests()
        {
            _context = GetParam<IApplicationDbContext>();
        }

        [Fact]
        public async Task Should_Create_Task_Successfully()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                PersonName = "João Silva",
                Description = "Desenvolvimento de API",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                HourlyRate = 50.0m
            };

            // Act
            var result = await HandleAsync(command);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();

            await _context.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Should_Add_Task_To_Context()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                PersonName = "Maria Santos",
                Description = "Teste de funcionalidade",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                HourlyRate = 75.0m
            };

            // Act
            await HandleAsync(command);

            // Assert
            _context.Tasks.Received(1).Add(Arg.Any<TaskEntity>());
        }

        [Fact]
        public async Task Should_Throw_Validation_Exception_When_Command_Is_Invalid()
        {
            // Arrange
            var validator = Substitute.For<AbstractValidator<CreateTaskCommand>>();
            var validationFailures = new List<FluentValidation.Results.ValidationFailure>
            {
                new FluentValidation.Results.ValidationFailure("PersonName", "Nome da pessoa é obrigatório")
            };

            validator.ValidateAsync(Arg.Any<ValidationContext<CreateTaskCommand>>(), Arg.Any<CancellationToken>())
                .Returns(new FluentValidation.Results.ValidationResult(validationFailures));

            SetupValidators(new[] { validator });

            var command = new CreateTaskCommand
            {
                PersonName = "", // Nome vazio para forçar erro de validação
                Description = "Teste",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                HourlyRate = 50.0m
            };

            // Act & Assert
            await Assert.ThrowsAsync<AggregateException>(() => HandleAsync(command));
        }
    }
}