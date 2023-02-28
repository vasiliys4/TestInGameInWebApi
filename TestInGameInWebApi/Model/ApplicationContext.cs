using Microsoft.EntityFrameworkCore;

namespace TestInGameInWebApi.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<GenreBook> genreBooks { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }
        
    }
}

