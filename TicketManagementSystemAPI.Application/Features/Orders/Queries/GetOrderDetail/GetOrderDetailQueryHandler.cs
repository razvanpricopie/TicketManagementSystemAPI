using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Exceptions;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;

        public GetOrderDetailQueryHandler(IMapper mapper, IOrderRepository orderRepository, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            Order @order = await _orderRepository.GetByIdAsync(request.Id);

            if (@order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            List<Ticket> tickets = await _ticketRepository.GetTicketByOrderId(@order.Id);

            if (tickets == null)
                throw new NotFoundException(nameof(Ticket), request.Id);

            @order.Tickets = tickets;

            OrderDetailVm orderDetailDto = _mapper.Map<OrderDetailVm>(@order);

            return orderDetailDto;
        }
    }
}
