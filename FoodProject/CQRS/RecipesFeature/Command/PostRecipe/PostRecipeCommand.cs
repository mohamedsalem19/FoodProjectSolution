using MediatR;

namespace FoodProject.CQRS.RecipesFeature.Command.PostRecipe
{
    public class PostRecipeCommand :IRequest<string>
    {
        public PostRecipeDto Dto { get; set; }
    }
}
