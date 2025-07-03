using System.Collections.Generic;
using FluentValidation;
using MediatR;
using NSubstitute;

namespace GitClock.Application.Tests
{
    public abstract class HandlerTestBase<THandler, TRequest, TResponse>
        where THandler : class, IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly THandler handler;
        protected readonly object[] parameters;
        protected readonly IEnumerable<AbstractValidator<TRequest>> validators;

        protected HandlerTestBase()
        {
            parameters = GetMockedParameters().ToArray();
            handler = (THandler)Activator.CreateInstance(typeof(THandler), parameters)!;
            validators = GetParam<IEnumerable<AbstractValidator<TRequest>>>();
        }

        private static IEnumerable<object> GetMockedParameters()
        {
            var constructor = typeof(THandler).GetConstructors().FirstOrDefault();
            var constructorParameters = constructor!.GetParameters();

            foreach (var parameter in constructorParameters)
            {
                if (parameter.ParameterType == typeof(IEnumerable<AbstractValidator<TRequest>>))
                {
                    // Para validators, criamos uma lista vazia por padrão
                    yield return new List<AbstractValidator<TRequest>>();
                }
                else
                {
                    yield return Substitute.For([parameter.ParameterType], []);
                }
            }
        }

        protected TParamType GetParam<TParamType>()
        {
            return (TParamType)parameters.ToList().Find(p => p is TParamType)!;
        }

        protected void SetupValidators(IEnumerable<AbstractValidator<TRequest>> customValidators)
        {
            // Substitui os validators padrão por validators customizados
            var validatorParameterIndex = Array.FindIndex(parameters, p => p is IEnumerable<AbstractValidator<TRequest>>);
            if (validatorParameterIndex >= 0)
            {
                parameters[validatorParameterIndex] = customValidators;
                // Recria o handler com os novos validators
                var handler = (THandler)Activator.CreateInstance(typeof(THandler), parameters)!;
            }
        }

        protected async Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            return await handler.Handle(request, cancellationToken);
        }
    }
}