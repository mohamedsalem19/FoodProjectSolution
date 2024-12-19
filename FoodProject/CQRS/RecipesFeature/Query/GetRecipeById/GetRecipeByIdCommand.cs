using FoodProject.ViewModels;
using MediatR;

namespace FoodProject.CQRS.RecipesFeature.Query.GetRecipeById
{
    public class GetRecipeByIdCommand :IRequest<ResponseViewModel<GetRecipeByIdDto>>
    {
        public int Id { get; set; }
    }
}
