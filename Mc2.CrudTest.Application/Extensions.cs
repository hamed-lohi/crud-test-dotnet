using Mc2.CrudTest.Domain.Factories;
using Microsoft.Extensions.DependencyInjection;
using Mc2.CrudTest.Shared.Commands;

namespace Mc2.CrudTest.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ICustomerFactory, CustomerFactory>();

            return services;
        }
    }
}
