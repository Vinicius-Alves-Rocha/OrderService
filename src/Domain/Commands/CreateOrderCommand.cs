using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Domain.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public Order Order { get; set; }

        public CreateOrderCommand(Order order)
        {
            Order = order;
        }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
        {
            private readonly IOrderRepository orderRepository;

            public CreateOrderCommandHandler(IOrderRepository orderRepository)
            {
                this.orderRepository = orderRepository;
            }

            public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                await orderRepository.InsertAsync(request.Order);
            }
        }
    }
}
