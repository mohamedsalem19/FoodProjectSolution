namespace FoodProject.Models
{
    public class RecipesItems : BaseModel
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int TagId { get; set; }
        public int? Discount { get; set; }
        public bool IsFavorite { get; set; } = false;
        public Tag Tag { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
