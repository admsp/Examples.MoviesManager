using Microsoft.EntityFrameworkCore;

namespace MoviesManager.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (
            DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesManager.Models.Movie> Movie { get; set; }
    }
}