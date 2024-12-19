using FoodProject.ViewModels;
using MediatR;

namespace FoodProject.CQRS.RecipesFeature.Query.GetAllRecipes
{
    public class GetAllRecipesCommand :IRequest<ResponseViewModel<List<GetAllRecipesDto>>>
    {
    }
}
