using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.DeleteEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList;
using TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList;
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
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Order, OrderListVm>().ReverseMap();
            CreateMap<Order, OrderDetailVm>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
        }
    }
}
