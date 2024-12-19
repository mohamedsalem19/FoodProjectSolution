namespace FoodProject.CQRS.RecipesFeature.Query.GetRecipeById
{
    public class GetRecipeByIdDto
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string TagName { get; set; }
        public int? Discount { get; set; }
        public bool IsFavorite { get; set; } = false;
        public string CategoryName { get; set; }
    }
}
