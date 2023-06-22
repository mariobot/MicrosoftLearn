

namespace VarifyEmail.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseSqlServer("Data Source=MBOTERO\\MBOTERO;Integrated Security=True");
        }

        public DbSet<User> Users => Set<User>();
    }
}
