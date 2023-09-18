using Microsoft.EntityFrameworkCore;
using SimpleVideoGameLibrary.Shared;

namespace SimpleVideoGameLibrary.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
                            
        }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
