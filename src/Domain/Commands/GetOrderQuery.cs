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
    public class GetOrderQuery : IRequest<IEnumerable<Order>>
    {
        public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<Order>>
        {
            private readonly IOrderRepository orderRepository;
            public GetOrderQueryHandler(IOrderRepository orderRepository)
            {
                this.orderRepository = orderRepository;
            }

            public async Task<IEnumerable<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                return await orderRepository.GetAsync();
            }
        }
    }
}
