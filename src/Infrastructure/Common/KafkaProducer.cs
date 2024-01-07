using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public static class KafkaProducer
    {
        public static async Task ProduceMessage(string topic, string kafkaMessage)
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string>
                {
                    Key = null,
                    Value = kafkaMessage
                });
            }
        }
    }
}
