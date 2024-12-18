namespace FoodProject.Models
{
    public class Tag : BaseModel
    {
        public Tag()
        {
            RecipesItems = new List<RecipesItems>();
        }
        public string Name { get; set; }

        public ICollection<RecipesItems> RecipesItems { get; set; }


    }
}
