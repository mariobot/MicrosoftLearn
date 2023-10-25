using BlazorCrudDotNet8.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        public DbSet<Game> Games { get; set; }
    }
}
