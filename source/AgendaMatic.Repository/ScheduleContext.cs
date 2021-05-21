using AgendaMatic.Domain.Entities;
using AgendaMatic.Repository.Config;
using Microsoft.EntityFrameworkCore;

namespace AgendaMatic.Repository
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ScheduleConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}

