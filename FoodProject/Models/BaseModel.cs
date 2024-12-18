namespace FoodProject.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
