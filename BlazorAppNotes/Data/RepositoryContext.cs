using Microsoft.EntityFrameworkCore;

namespace BlazorAppNotes.Data
{
    public class RepositoryContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData
                (
                    new Note { Id = 1, Title = "Title 1", Content = "Content 1"},
                    new Note { Id = 2, Title = "Title 2", Content = "Content 2" },
                    new Note { Id = 3, Title = "Title 3", Content = "Content 3" },
                    new Note { Id = 4, Title = "Title 4", Content = "Content 4" },
                    new Note { Id = 5, Title = "Title 5", Content = "Content 5" },
                    new Note { Id = 6, Title = "Title 6", Content = "Content 6" }
                );
        }
        public DbSet<Note> Notes { get; set; }
    }
}
