using FoodProject.CQRS.CategoryFeature.Query.GetAllCategory;
using FoodProject.CQRS.RecipesFeature.Command.PostRecipe;
using FoodProject.CQRS.RecipesFeature.Query.GetAllRecipes;
using FoodProject.CQRS.RecipesFeature.Query.GetRecipeById;
using FoodProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        IMediator _mediator;
        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<string> PostRecipr(PostRecipeDto dto)
        {
            return await _mediator.Send(new PostRecipeCommand() { Dto = dto });
        }
        [HttpGet]

        public async Task<ResponseViewModel<List<GetAllRecipesDto>>> GetAllRecipes()
        {
            return await _mediator.Send(new GetAllRecipesCommand());
        }
        [HttpGet("{id}")]
        public async Task<ResponseViewModel<GetRecipeByIdDto>> GetRecipeById(int id)
        {
            return await _mediator.Send(new GetRecipeByIdCommand() { Id = id });
        }
    }
}
