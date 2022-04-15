using Microsoft.EntityFrameworkCore;

namespace Meetups.Persistence
{
    // Starts with the app and checks weather a database exists or not and if not it will be created based on dbContext
    public class DbInitializer
    {
        public static void Initialize (MeetupsDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
