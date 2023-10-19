using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .WithMessage("{PropertyName} must not be null or empty");

            RuleFor(p => p.OrderTotal) 
                .NotNull()
                .WithMessage("{PropertyName} must not be null or empty")
                .GreaterThan(0);

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .LessThan(DateTime.Now);
        }
    }
}
