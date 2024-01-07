using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid OrderId { get; set; }
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
        {
            private readonly IOrderRepository orderRepository;
            public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
            {
                this.orderRepository = orderRepository;
            }

            public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                return await orderRepository.GetByIdAsync(request.OrderId);
            }
        }
    }
}
