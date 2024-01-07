using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Common;
using System.Text.Json;

namespace Infrastructure.Producers
{
    public class CreateItemProducer : ICreateItemProducer
    {
        public async Task ProduceMessageAsync(Item item)
        {
            await KafkaProducer.ProduceMessage("CreateOrderItem", JsonSerializer.Serialize(item));
        }
    }
}
