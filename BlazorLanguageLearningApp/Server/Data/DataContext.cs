using BlazorLanguageLearningApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlazorLanguageLearningApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User>  Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<AnswerRecord> AnswersRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerRecord>()
                .Property(b => b.Created)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
