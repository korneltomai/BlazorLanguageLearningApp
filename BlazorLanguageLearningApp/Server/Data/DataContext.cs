using BlazorLanguageLearningApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorLanguageLearningApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
