using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
