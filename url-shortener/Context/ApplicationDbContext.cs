using Microsoft.EntityFrameworkCore;
using UrlShortener.Model;

namespace UrlShortener.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {                
        }

        public DbSet<ShortenerUrl> ShortenedUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenerUrl>(builder =>
            {
                builder
                    .Property(shortenerUrl => shortenerUrl.Code)
                    .HasMaxLength(ShortLinkSettings.Length);

                builder
                    .HasIndex(shortenerUrl => shortenerUrl.Code)
                    .IsUnique();
            });
        }
    }
}
