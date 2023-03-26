using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Application.Responses;

namespace TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {

        }

        public CreateCategoryDto Category { get; set; }
    }
}
