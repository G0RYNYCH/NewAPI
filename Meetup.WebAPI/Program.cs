using Meetups.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.WebAPI
{
    //точка входа в приложение
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //вызов инициалзации бд
            using(var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;// сервис провайдер используется для разрешения зависисмостей
                try
                {
                    var context = serviceProvider.GetRequiredService<MeetupsDbContext>();// получаем контекст
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {

                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
