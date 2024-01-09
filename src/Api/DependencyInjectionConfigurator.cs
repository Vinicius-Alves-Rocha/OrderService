
using Domain.Commands;
using Domain.Interfaces.Repositories;
using Infrastructure.Consumers;
using Infrastructure.Consumers.Interfaces;
using Infrastructure.Producers;
using Infrastructure.Repositories;

namespace Api
{
    public static class DependencyInjectionConfigurator
    {
        public static void ConfigureDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICreateItemProducer, CreateItemProducer>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<ICreateOrderConsumer, CreateOrderConsumer>();

            serviceCollection.ConfigureMediatorDependecyInjection();
        }

        private static void ConfigureMediatorDependecyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetOrderQuery).Assembly));
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetOrderByIdQuery).Assembly));
        }
    }
}
