using Application.Persons;
using Application.Persons.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            return services;
        }
    }
}
