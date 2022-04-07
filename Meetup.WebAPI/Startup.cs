using Meetups.Aplication;
using Meetups.Aplication.Common.Mapping;
using Meetups.Aplication.Interfaces;
using Meetups.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Meetup.WebAPI
{
    //configuration of the app
    public class Startup
    {
        public IConfiguration Configuration { get; }//?

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(configure =>
            {
                configure.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));// info about current assembly
                configure.AddProfile(new AssemblyMappingProfile(typeof(IMeetupsDbContext).Assembly));
            });
            services.AddApplication();
            services.AddPersistance(Configuration);// get configuration through constructor and pass to the mrthod
            services.AddCors(options => 
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // we indicate here what the application will use (the order matters)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();// change http to https
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();// эндпоинт меняем таким обрвзом , чтобы роутинг мапился на названия контроллеров и их методы
            });
        }
    }
}
