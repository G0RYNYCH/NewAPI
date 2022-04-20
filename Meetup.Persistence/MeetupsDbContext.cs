using Meetups.Domain;
using Meetups.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Meetups.Persistence
{
    public class MeetupsDbContext : DbContext
    {
        public DbSet<Meetup> Meetups { get; set; }

        public MeetupsDbContext(DbContextOptions<MeetupsDbContext> options): base(options) { }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MeetupConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
