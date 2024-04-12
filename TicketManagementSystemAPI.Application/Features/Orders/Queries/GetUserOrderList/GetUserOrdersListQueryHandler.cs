using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList
{
    public class GetUserOrdersListQueryHandler : IRequestHandler<GetUserOrdersListQuery, List<UserOrderListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetUserOrdersListQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<UserOrderListVm>> Handle(GetUserOrdersListQuery request, CancellationToken cancellationToken)
        {
            List<Order> allUserOrders = (await _orderRepository.GetOrdersListWithTicketsByUserIdAsync(request.UserId)).OrderByDescending(x => x.CreatedDate).ToList();

            return _mapper.Map<List<UserOrderListVm>>(allUserOrders);
        }
    }
}
