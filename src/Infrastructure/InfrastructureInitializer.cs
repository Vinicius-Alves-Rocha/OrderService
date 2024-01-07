using Infrastructure.Common;
using Infrastructure.Repositories.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class InfrastructureInitializer
    {
        public static void ConfigureInfrastructure(this IServiceCollection serviceCollection)
        {
            //applicationBuilder.subs
            serviceCollection.AddDbContext<OrderDbContext>();
            serviceCollection.AddHostedService<KafkaConsumerConfig>();
        }
    }
}
