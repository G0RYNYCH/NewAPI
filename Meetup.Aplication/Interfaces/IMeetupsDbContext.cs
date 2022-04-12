using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Interfaces
{
    // this interface is a part of the app, but the implementation of him is outside of the application project (Meetups.Persistance.MeetupsDbContext)
    public interface IMeetupsDbContext
    {
        DbSet<Meetup> Meetups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
