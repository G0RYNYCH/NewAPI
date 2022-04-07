using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Interfaces
{
    public interface IMeetupsDbContext
    {
        DbSet<Meetup> Meetups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
