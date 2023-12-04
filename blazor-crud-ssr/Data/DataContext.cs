using BlazorCrudSSR.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudSSR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Cyberpunk 2077", Publisher = "CD Project", ReleaseDate = 2020 },
                new VideoGame { Id = 2, Title = "Elden Ring", Publisher = "FromSoftware", ReleaseDate = 2022 },
                new VideoGame { Id = 3, Title = "The Legend of Zelda", Publisher = "Nintendo", ReleaseDate = 1998 }
            );
        }

        public DbSet<VideoGame> VideoGames { get; set; }

    }
}
