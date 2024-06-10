using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Infrastructure.StripePayment.Validations
{
    public class CreateOrderValidator : AbstractValidator<Order>
    {
        public CreateOrderValidator()
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .WithMessage("{PropertyName} must not be null or empty")
                .NotEqual(Guid.Empty)
                .WithMessage("{PropertyName} must not be null or empty");

            RuleFor(p => p.OrderTotal)
                .NotNull()
                .WithMessage("{PropertyName} must not be null or empty")
                .Equal(p => p.Tickets.Sum(t => t.Quantity * t.Price))
                .GreaterThan(0).When(p => p.Tickets != null && p.Tickets.Any());

            RuleFor(p => p.Tickets)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleForEach(p => p.Tickets).ChildRules(t =>
            {
                t.RuleFor(p => p.EventId)
                    .NotNull()
                    .WithMessage("{PropertyName} must not be null or empty")
                    .NotEqual(Guid.Empty)
                    .WithMessage("{PropertyName} must not be null or empty");

                t.RuleFor(p => p.Quantity)
                    .NotNull()
                    .WithMessage("{PropertyName} must not be null or empty")
                    .GreaterThan(0);
            });
        }
    }
}
