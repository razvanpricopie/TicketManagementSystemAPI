using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
