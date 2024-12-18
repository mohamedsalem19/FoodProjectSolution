namespace FoodProject.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            RecipesItems = new List<RecipesItems>();
        }
        public string Name { get; set; }

        public ICollection<RecipesItems> RecipesItems { get; set; }
    }
}
