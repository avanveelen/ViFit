using Microsoft.EntityFrameworkCore;

namespace ViFit.Infrastructure.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>()
                .HasKey(log => new { log.AggregateId, log.Version });
            base.OnModelCreating(modelBuilder);
        }
    }
}
