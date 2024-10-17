namespace SurvivorPractice.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }


        public List<CompetitorDto> Competitors { get; set; }
    }
}
