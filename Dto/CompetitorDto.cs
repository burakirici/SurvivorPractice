namespace SurvivorPractice.Dto
{
    public class CompetitorDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifydDate { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }
    }
}
