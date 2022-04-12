using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Meetups.Aplication.Interfaces;

namespace Meetups.Persistence
{
    //use extention method to add db context into the app
    public static class ServiceCollectionExtentions
    {
        // add db context usage and register it
        public static IServiceCollection AddPersistance (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<MeetupsDbContext>(options => 
            {
                options.UseNpgsql(connectionString, x => x.MigrationsAssembly("Meetups.Persistence"));
            });
            services.AddScoped<IMeetupsDbContext>(provider => provider.GetService<MeetupsDbContext>());

            return services;
        }
    }
}
