using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrderListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderListQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderListVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            List<Order> allOrders = (await _orderRepository.GetOrdersListWithTicketsAsync()).OrderBy(x => x.CreatedDate).ToList();

            return _mapper.Map<List<OrderListVm>>(allOrders);
        }
    }
}
