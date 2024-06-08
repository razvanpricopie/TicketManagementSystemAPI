using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Application.Contracts.Infrastructure;
using TicketManagementSystemAPI.Application.Models.Mail;
using TicketManagementSystemAPI.Application.Models.StripePayment;
using TicketManagementSystemAPI.Infrastructure.Mail;
using TicketManagementSystemAPI.Infrastructure.StripePayment;

namespace TicketManagementSystemAPI.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));

            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<IStripeService, StripeService>();

            return services;
        }
    }
}
