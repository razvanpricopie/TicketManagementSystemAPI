using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoryWithEvents;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.DeleteEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList;
using TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, Features.Categories.Queries.GetCategoriesListWithEvents.CategoryEventDto>().ReverseMap();
            CreateMap<Event, Features.Categories.Queries.GetCategoryWithEvents.CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CategoryWithEventsVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Order, OrderListVm>().ForMember(dto => dto.NumberOfTickets, opt => opt.MapFrom(o => o.Tickets.Count));
            CreateMap<Order, UserOrderListVm>();
            CreateMap<Order, OrderDetailVm>();
            CreateMap<CreateOrderCommand, Order>();

            CreateMap<Ticket, Features.Orders.Commands.CreateOrder.TicketDto>().ReverseMap();
            CreateMap<Ticket, Features.Orders.Queries.GetOrdersList.TicketDto>().ReverseMap();
            CreateMap<Ticket, Features.Orders.Queries.GetUserOrderList.TicketDto>().ReverseMap();
            CreateMap<Ticket, Features.Orders.Queries.GetOrderDetail.TicketDto>()
                .ForMember(dto => dto.EventName, opt => opt.MapFrom(t => t.Event.Name));
        }
    }
}
