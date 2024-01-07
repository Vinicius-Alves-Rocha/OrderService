using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Consumers.Interfaces;
using System.Text.Json;

namespace Infrastructure.Consumers
{
    public class CreateOrderConsumer : ICreateOrderConsumer
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICreateItemProducer createItemProducer;

        public CreateOrderConsumer(IOrderRepository orderRepository,
            ICreateItemProducer createItemProducer)
        {
            this.orderRepository = orderRepository;
            this.createItemProducer = createItemProducer;
        }

        public async Task HandleKafkaMessage(string topicMessage)
        {
            var createOrderObject = JsonSerializer.Deserialize<Order>(topicMessage);

            if (createOrderObject == null) 
            {
                return;
            }

            var changesInDb = await orderRepository.InsertAsync(createOrderObject);

            if (changesInDb <= 0)
            {
                foreach (var item in createOrderObject.Items)
                {
                    await createItemProducer.ProduceMessageAsync(item);
                }
            }

            
        }
    }
}
