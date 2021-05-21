using AgendaMatic.Domain.Entities;
using AgendaMatic.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMatic.Repository.Config
{
    public class ScheduleConfig  : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(nameof(Schedule).ToDatabaseFormat());

            builder.HasKey(x => x.ScheduleId);

            builder.Property(x => x.ScheduleId)
                .IsRequired()
                .ValueGeneratedNever()
                .HasColumnName(nameof(Schedule.ScheduleId).ToDatabaseFormat());

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(nameof(Schedule.UserId).ToDatabaseFormat());

            builder.Property(x => x.ScheduleTime)
                .IsRequired()
                .HasColumnName(nameof(Schedule.ScheduleTime).ToDatabaseFormat())
                .HasColumnType("datetime2");
        }
    }
}