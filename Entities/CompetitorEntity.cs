namespace SurvivorPractice.Entities
{
    public class CompetitorEntity : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; } 
        public CategoryEntity Category { get; set; }
    }
}
