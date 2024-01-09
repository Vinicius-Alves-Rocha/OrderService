using Confluent.Kafka;
using Infrastructure.Consumers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Common
{
    public class KafkaConsumerConfig : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private IConsumer<Null, string> consumer { get; init; }

        private const string CreateOrderTopic = "CreateOrderTopic";

        public KafkaConsumerConfig(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "queue-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.Run(async () =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                consumer.Subscribe(CreateOrderTopic);

                var consumerMessage = consumer.Consume(stoppingToken);
                using (var scope = serviceProvider.CreateScope())
                {
                    var createOrderConsumer = scope.ServiceProvider.GetService<ICreateOrderConsumer>();

                    createOrderConsumer?.HandleKafkaMessage(consumerMessage.Message.Value);
                }
            }

            consumer.Close();
        });
    }
}
