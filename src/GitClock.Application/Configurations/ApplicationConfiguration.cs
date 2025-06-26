using FluentValidation;
using GitClock.Application.Features;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GitClock.Application.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(HandlerBase<,>).Assembly));

            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            var type = typeof(AbstractValidator<>);
            var assembly = typeof(HandlerBase<,>).Assembly;
            (from classes in assembly.GetTypes()
             where classes.BaseType != null
             && classes.BaseType!.IsAbstract
             && classes.BaseType!.Name.Contains(type.Name)
             select classes)
             .ToList()
             .ForEach(delegate (Type e)
             {
                 services.AddTransient(e.BaseType!, e);
             });

            return services;
        }
    }
}