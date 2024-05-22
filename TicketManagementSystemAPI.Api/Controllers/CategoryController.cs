using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.DeleteCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoryWithEvents;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allcategories", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            List<CategoryListVm> categories = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(categories);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory };

            List<CategoryEventListVm> categories = await _mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(categories);
        }

        [HttpGet("{categoryId}", Name = "GetCategoryWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryWithEventsVm>> GetCategoryWithEvents(Guid categoryId, bool includeHistory)
        {
            GetCategoryWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoryWithEventsQuery() { Id = categoryId, IncludeHistory = includeHistory };

            CategoryWithEventsVm category = await _mediator.Send(getCategoriesListWithEventsQuery);

            return Ok(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addcategory", Name = "AddCategory")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> CreateCategory([FromForm] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommand);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{CategoryId}", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCategory([FromForm] UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{CategoryId}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCategory(Guid categoryId)
        {
            DeleteCategoryCommand deleteCategoryCommand = new DeleteCategoryCommand() { CategoryId = categoryId };

            await _mediator.Send(deleteCategoryCommand);

            return NoContent();
        }
    }
}
