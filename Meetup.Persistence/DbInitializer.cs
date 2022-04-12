using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Persistence
{
    // Starts with the app and checks weather a database exists or not and if not it will be created based on dbContext
    public class DbInitializer
    {
        public static void Initialize (MeetupsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
