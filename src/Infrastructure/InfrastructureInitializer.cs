using Infrastructure.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class InfrastructureInitializer
    {
        public static void ConfigureInfrastructure(this IApplicationBuilder applicationBuilder, string[] args)
        {
            //applicationBuilder.subs
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((collection) => collection.AddHostedService<KafkaConsumerConfig>());
    }
}
