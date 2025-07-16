using GitClock.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitClock.Domain.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TaskEntity> Tasks { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}