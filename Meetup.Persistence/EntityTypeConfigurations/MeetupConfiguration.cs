using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetups.Domain;

namespace Meetups.Persistence.EntityTypeConfigurations
{
    //to decrease size of OnModelCreating method and make a conceptual separation we can extract all configurations of a type in another class that implements IEntityTypeConfiguration
    public class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {        
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}
