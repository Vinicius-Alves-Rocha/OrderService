using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Common;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Producers
{
    public class CreateItemProducer : ICreateItemProducer
    {
        
        private readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles };

        public async Task ProduceMessageAsync(Item item)
        {
            await KafkaProducer.ProduceMessage("CreateOrderItem", JsonSerializer.Serialize(item, JsonSerializerOptions));
        }
    }
}
