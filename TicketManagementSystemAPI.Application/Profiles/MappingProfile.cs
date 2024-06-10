using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoryWithEvents;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.DislikeEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.LikeEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserDislikedEventsList;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserEventRateStatus;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList;
using TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList;
using TicketManagementSystemAPI.Application.Models.OpenAI;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>();
            CreateMap<Event, EventDetailVm>();
            CreateMap<CreateEventCommand, Event>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.Image)));
            CreateMap<UpdateEventCommand, Event>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.Image)));
            CreateMap<Event, Features.Categories.Queries.GetCategoriesListWithEvents.CategoryEventDto>();
            CreateMap<Event, Features.Categories.Queries.GetCategoryWithEvents.CategoryEventDto>();
            CreateMap<Event, TicketEventDto>();
            CreateMap<LikeEventCommand, EventLikeStatus>();
            CreateMap<DislikeEventCommand, EventLikeStatus>();
            CreateMap<EventLikeStatus, UserEventLikeStatusVm>();
            CreateMap<Event, UserLikedEventsListVm>();
            CreateMap<Event, UserDislikedEventsListVm>();
            CreateMap<Event, OpenAIEventListResponse>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CategoryWithEventsVm>();
            CreateMap<CreateCategoryCommand, Category>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.Image)));
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryCommand, Category>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.Image))); ;

            CreateMap<Order, OrderListVm>().ForMember(dto => dto.NumberOfTickets, opt => opt.MapFrom(o => o.Tickets.Count));
            CreateMap<Order, UserOrderListVm>();
            CreateMap<Order, OrderDetailVm>();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();

            CreateMap<Ticket, Features.Orders.Commands.CreateOrder.TicketDto>().ReverseMap();
            CreateMap<Ticket, Features.Orders.Queries.GetOrdersList.TicketDto>().ReverseMap();
            CreateMap<Ticket, Features.Orders.Queries.GetUserOrderList.TicketDto>().ReverseMap();
            CreateMap<Ticket, Features.Orders.Queries.GetOrderDetail.TicketDto>()
                .ForMember(dto => dto.EventName, opt => opt.MapFrom(t => t.Event.Name)).ReverseMap();
        }

        private byte[] ConvertFormFileToByteArray(IFormFile file)
        {
            if (file == null)
                return null;

            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
