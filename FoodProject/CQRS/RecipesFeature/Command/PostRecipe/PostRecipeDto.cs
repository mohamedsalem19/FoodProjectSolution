using FoodProject.Models;

namespace FoodProject.CQRS.RecipesFeature.Command.PostRecipe
{
    public class PostRecipeDto
    {
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int TagId { get; set; }
        public int? Discount { get; set; }
        public bool IsFavorite { get; set; } = false;
        public int CategoryId { get; set; }
    }
}
