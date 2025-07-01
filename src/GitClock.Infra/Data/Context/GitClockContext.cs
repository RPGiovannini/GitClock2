using GitClock.Domain.Entities;
using GitClock.Domain.Interfaces;
using GitClock.Infra.Configurations.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GitClock.Infra.Data.Context;

public class GitClockContext : DbContext, IApplicationDbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }

    public GitClockContext(DbContextOptions<GitClockContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
    }
}

