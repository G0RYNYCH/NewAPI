using FluentValidation;
using MediatR;
using Meetups.Aplication.Common.Behavior;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Meetups.Aplication
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
