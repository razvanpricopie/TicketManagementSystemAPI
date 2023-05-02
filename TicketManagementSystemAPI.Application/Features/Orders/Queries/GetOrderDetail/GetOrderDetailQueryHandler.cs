using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Order> _orderRepository;

        public GetOrderDetailQueryHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            Order @order = await _orderRepository.GetByIdAsync(request.Id);
            OrderDetailVm orderDetailDto = _mapper.Map<OrderDetailVm>(@order);

            return orderDetailDto;
        }
    }
}
