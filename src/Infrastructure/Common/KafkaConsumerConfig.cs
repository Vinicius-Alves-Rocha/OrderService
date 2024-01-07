using Confluent.Kafka;
using Domain.Models;
using Infrastructure.Consumers;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public class KafkaConsumerConfig : IHostedService
    {
        private readonly ICreateOrderConsumer createOrderConsumer;
        private IConsumer<Null, string> consumer { get; init; }

        private const string CreateOrderTopic = "CreateOrderTopic";

        public KafkaConsumerConfig(ICreateOrderConsumer createOrderConsumer)
        {
            this.createOrderConsumer = createOrderConsumer;

            var consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = "localhost:9092",
                GroupId = "queue-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested)
            {
                consumer.Subscribe(CreateOrderTopic);

                var consumerMessage = consumer.Consume(cancellationToken);
                createOrderConsumer.HandleKafkaMessage(consumerMessage.Message.Value);

                consumer.Close();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            consumer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
