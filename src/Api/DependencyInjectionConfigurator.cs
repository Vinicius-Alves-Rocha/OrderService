
using Domain.Interfaces.Repositories;
using Infrastructure.Interfaces;

namespace Api
{
    public static class DependencyInjectionConfigurator
    {
        public static void ConfigureDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICreateItemProducer>();
            serviceCollection.AddTransient<IOrderRepository>();
            serviceCollection.AddTransient<ICreateOrderConsumer>();
        }
    }
}
