using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Data.Context
{
    public class StreamLineDbContext : DbContext
    {
        public StreamLineDbContext(DbContextOptions<StreamLineDbContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionsAnswer> QuestionsAnswers { get; set; }
        public DbSet<TestsResult> TestsResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(UserConfigure);
            modelBuilder.Entity<Test>(TestConfigure);
            modelBuilder.Entity<Question>(QuestionConfigure);
            modelBuilder.Entity<QuestionsAnswer>(QuestionsAnswerConfigure);
            modelBuilder.Entity<TestsResult>(TestsResultConfigure);
        }

        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(p => p.Id);
            builder.Property(u => u.Name).IsRequired().HasColumnType("nvarchar(30)");
            builder.Property(u => u.Email).IsRequired().HasColumnType("nvarchar(30)");
            builder.Property(u => u.Password).IsRequired().HasColumnType("nvarchar(30)");
            builder.HasIndex(u => u.Name).IsUnique();
        }

        public void TestConfigure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("Tests").HasKey(p => p.Id);
            builder.Property(t => t.Name).IsRequired().HasColumnType("nvarchar(100)");
        }

        public void QuestionConfigure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions").HasKey(p => p.Id);
            builder.Property(q => q.Value).IsRequired().HasColumnType("nvarchar(1000)");
            builder.HasMany(q => q.Answers).WithOne(a => a.Question);
            builder.HasMany(t => t.Tests).WithMany(q => q.Questions).UsingEntity(x => x.ToTable("Test_Question"));
        }

        public void QuestionsAnswerConfigure(EntityTypeBuilder<QuestionsAnswer> builder)
        {
            builder.ToTable("QuestionsAnswers").HasKey(p => p.Id);
            builder.Property(a => a.Value).HasColumnType("nvarchar(1000)");
            builder.Property(a => a.IsRight).IsRequired().HasColumnType("bit");
        }

        public void TestsResultConfigure(EntityTypeBuilder<TestsResult> builder)
        {
            builder.ToTable("TestsResults").HasKey(p => p.Id);
            builder.Property(r => r.Result).IsRequired();
            builder.HasOne(r => r.User).WithMany(u => u.Results);
            builder.HasOne(r => r.Test).WithMany(t => t.Results);
        }
    }
}
