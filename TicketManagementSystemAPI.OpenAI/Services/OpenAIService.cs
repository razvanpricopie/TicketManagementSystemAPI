using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.OpenAI;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Models.OpenAI;
using TicketManagementSystemAPI.Domain.Entities;
using TicketManagementSystemAPI.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TicketManagementSystemAPI.OpenAI.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly IMapper _mapper;
        private readonly OpenAISettings _openAISettings;
        private readonly TicketManagementSystemDbContext _dbContext;
        private readonly IEventRepository _eventRepository;
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Ticket> _ticketRepository;

        public OpenAIService(IMapper mapper, IOptions<OpenAISettings> openAISettings, TicketManagementSystemDbContext dbContext, IEventRepository eventRepository, IAsyncRepository<Order> orderRepository, IAsyncRepository<Ticket> ticketRepository)
        {
            _openAISettings = openAISettings.Value;
            _mapper = mapper;
            _dbContext = dbContext;
            _eventRepository = eventRepository;
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<OpenAIEventListResponse>> GetMostTenBoughtEvents()
        {
            string methodPrompt = "I want to fetch the most bought ten events";
         
            string systemPrompt = CreateSystemPrompt();
            string userPrompt = ConvertEventDataToPrompt(methodPrompt).Result;

            OpenAIAPI openAIApi = new OpenAIAPI(_openAISettings.Key);

            List<Event> eventBasedOnGeneratedQuery = await GenerateEventsBasedOnSqlQuery(openAIApi, systemPrompt, userPrompt);

            return _mapper.Map<List<OpenAIEventListResponse>>(eventBasedOnGeneratedQuery);
        }

        public async Task<List<OpenAIEventListResponse>> GetLastTenAddedEvents()
        {
            string methodPrompt = "I want to fetch the last ten added events - based on CreatedDate property";

            string systemPrompt = CreateSystemPrompt();
            string userPrompt = ConvertEventDataToPrompt(methodPrompt).Result;

            OpenAIAPI openAIApi = new OpenAIAPI(_openAISettings.Key);

            List<Event> eventBasedOnGeneratedQuery = await GenerateEventsBasedOnSqlQuery(openAIApi, systemPrompt, userPrompt);

            return _mapper.Map<List<OpenAIEventListResponse>>(eventBasedOnGeneratedQuery);
        }

        private async Task<List<Event>> GenerateEventsBasedOnSqlQuery(OpenAIAPI openAIApi, string systemPrompt, string userPrompt, string query = null, string errorMessage = null)
        {
            List<Event> eventBasedOnGeneratedQuery;

            if (errorMessage != null)
            {
                StringBuilder promptBuilder = new StringBuilder();
                promptBuilder.Append(userPrompt);
                promptBuilder.AppendLine();
                promptBuilder.AppendLine("Your last generated query result in some errors.");
                promptBuilder.AppendLine($"This is the query:{query}");
                promptBuilder.AppendLine();
                promptBuilder.AppendLine($"This is the error:{errorMessage}");
                userPrompt = promptBuilder.ToString();
            }

            var sqlQueriesAsChoiceList = await openAIApi.Chat.CreateChatCompletionAsync(new ChatRequest
            {
                Model = OpenAI_API.Models.Model.ChatGPTTurbo,
                Temperature = 0,
                Messages = new List<ChatMessage>
                {
                    new ChatMessage
                    {
                        Role = ChatMessageRole.System, TextContent = systemPrompt
                    },
                    new ChatMessage
                    {
                        Role = ChatMessageRole.User, TextContent = userPrompt
                    }
                }
            });

            try
            {
                eventBasedOnGeneratedQuery = (await _eventRepository.ListBySqlQueryAsync(sqlQueriesAsChoiceList.Choices[0].ToString())).ToList();
            }
            catch (Exception ex)
            {
                return await GenerateEventsBasedOnSqlQuery(openAIApi, systemPrompt, userPrompt, sqlQueriesAsChoiceList.ToString(), ex.Message);
            }

            return eventBasedOnGeneratedQuery;
        }

        private string CreateSystemPrompt()
        {
            StringBuilder promptBuilder = new StringBuilder();
            promptBuilder.AppendLine("You are an SQL generator that only returns SQL sequel statements and no natural language.");
            promptBuilder.AppendLine("Please return only sql query, no others charachters.");
            promptBuilder.AppendLine("You won't use SQL aliases, keep columns name as given.");
            promptBuilder.AppendLine("Given the table structure, definitions, some real data and user prompt.");
            promptBuilder.AppendLine("You have to include all entity's columns. If one to one relationship, include only foreign keys.");

            return promptBuilder.ToString();
        }

        private async Task<string> ConvertEventDataToPrompt(string userPrompt)
        {
            StringBuilder promptBuilder = new StringBuilder();

            promptBuilder.AppendLine(typeof(Event).Name + " table name: [TicketManagementSystemDb].[dbo].[Events]");
            promptBuilder.AppendLine(typeof(Event).Name + " entity structure:");
            var eventProperties = typeof(Event).GetProperties();
            foreach (var property in eventProperties)
            {
                promptBuilder.AppendLine($"{property.Name}: {property.PropertyType.Name}");
            }

            promptBuilder.AppendLine();

            promptBuilder.AppendLine("This is a list of five random " + typeof(Event).Name + " rows:");
            List<Event> fiveRanomEvents = (await _eventRepository.ListFiveRandomAsync()).ToList();

            foreach (var @event in fiveRanomEvents)
            {
                promptBuilder.AppendLine($"{@event.EventId} - {@event.Name} - {@event.Price} - {@event.Artist} - {@event.Date} - {@event.Description} - {@event.CategoryId} - {@event.Location} - {@event.Image} - {@event.CreatedBy} - {@event.CreatedDate} - {@event.LastModifiedBy} - {@event.LastModifiedDate}");
            }

            promptBuilder.AppendLine();
            promptBuilder.AppendLine();

            promptBuilder.AppendLine(typeof(Order).Name + " table name: [TicketManagementSystemDb].[dbo].[Orders]");
            promptBuilder.AppendLine(typeof(Order).Name + " entity structure:");
            var orderProperties = typeof(Order).GetProperties();
            foreach (var property in orderProperties)
            {
                promptBuilder.AppendLine($"{property.Name}: {property.PropertyType.Name}");
            }

            promptBuilder.AppendLine();

            promptBuilder.AppendLine("This is a list of five random " + typeof(Order).Name + " rows:");
            List<Order> fiveRanomOrders = (await _orderRepository.ListFiveRandomAsync()).ToList();

            foreach (var order in fiveRanomOrders)
            {
                promptBuilder.AppendLine($"{order.Id} - {order.UserId} - {order.OrderTotal} - {order.CreatedBy} - {order.CreatedDate} - {order.LastModifiedBy} - {order.LastModifiedDate}");
            }

            promptBuilder.AppendLine();
            promptBuilder.AppendLine();

            promptBuilder.AppendLine(typeof(Ticket).Name + " table name: [TicketManagementSystemDb].[dbo].[Tickets]");
            promptBuilder.AppendLine(typeof(Ticket).Name + " entity structure:");
            var ticketProperties = typeof(Ticket).GetProperties();
            foreach (var property in ticketProperties)
            {
                promptBuilder.AppendLine($"{property.Name}: {property.PropertyType.Name}");
            }

            promptBuilder.AppendLine();

            promptBuilder.AppendLine("This is a list of five random " + typeof(Ticket).Name + " rows:");
            List<Ticket> fiveRandomTickets = (await _ticketRepository.ListFiveRandomAsync()).ToList();

            foreach (var ticket in fiveRandomTickets)
            {
                promptBuilder.AppendLine($"{ticket.TicketId} - {ticket.EventId} - {ticket.OrderId} - {ticket.Quantity}");
            }

            promptBuilder.AppendLine();

            promptBuilder.AppendLine($"User prompt: {userPrompt}");

            return promptBuilder.ToString();
        }
    }
}
