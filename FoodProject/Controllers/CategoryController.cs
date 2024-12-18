using FoodProject.CQRS.CategoryFeature.Query.GetAllCategory;
using FoodProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<ResponseViewModel<List<GetAllCategoryDTO>>> GetAllCategories()
        {
            return await _mediator.Send(new GetAllCategoryQuery());
        }
    }
}
