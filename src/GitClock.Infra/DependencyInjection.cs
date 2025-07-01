using GitClock.Domain.Interfaces;
using GitClock.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitClock.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext>(provider =>
     provider.GetRequiredService<GitClockContext>());

        return services;
    }
}