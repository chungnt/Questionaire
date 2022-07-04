using Microsoft.EntityFrameworkCore;

namespace QuestionnaireApi.Entities
{
    public class QuestionaireDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public QuestionaireDbContext(DbContextOptions<QuestionaireDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionInfo> QuestionInfos { get; set; }
        public DbSet<QuestionInfoType> QuestionInfoTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>().ToTable("Form");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<QuestionInfo>().ToTable("QuestionInfo");
            modelBuilder.Entity<QuestionInfoType>().ToTable("QuestionInfoType");
        }
    }
}
