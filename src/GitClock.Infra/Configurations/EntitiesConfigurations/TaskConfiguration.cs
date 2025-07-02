using GitClock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitClock.Infra.Configurations.EntitiesConfigurations;

public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.PersonName).HasMaxLength(50).IsRequired();
        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.StartDate).IsRequired();
        builder.Property(t => t.EndDate).IsRequired();
        builder.Property(t => t.HourlyRate).HasPrecision(10, 2).IsRequired();
    }
}