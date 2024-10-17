namespace SurvivorPractice.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
