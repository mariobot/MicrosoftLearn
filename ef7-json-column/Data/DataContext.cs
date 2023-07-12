using Microsoft.EntityFrameworkCore;

namespace Ef7JsonColumns.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = MBOTERO\\MBOTERO;Initial Catalog = jsoncolumn;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().OwnsOne(sh => sh.Details, navigationBuilder => 
            { 
                navigationBuilder.ToJson();
            });
        }

        public DbSet<SuperHero> Heroes { get; set; }
    }
}
