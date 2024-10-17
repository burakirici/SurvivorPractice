using Microsoft.EntityFrameworkCore;
using SurvivorPractice.Entities;

namespace SurvivorPractice.Data
{
    public class SurvivorContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CompetitorEntity> Competitors { get; set; }

        public SurvivorContext(DbContextOptions<SurvivorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompetitorEntity>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<CategoryEntity>().HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
