using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Meetups.Aplication.Interfaces;

namespace Meetups.Persistence
{
    //исп. метод расширения добавление контекста бд в веб приложение (метод будет использоваться для настройки веб апи)
    public static class DependancyInjection
    {
        // добавлят использование контекста бд и регистрирует его 
        public static IServiceCollection AddPersistance (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<MeetupsDbContext>(options => 
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IMeetupsDbContext>(provider => provider.GetService<MeetupsDbContext>());

            return services;
        }
    }
}
