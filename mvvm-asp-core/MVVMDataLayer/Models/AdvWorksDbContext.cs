using Microsoft.EntityFrameworkCore;
using MVVMEntityLayer;

namespace MVVMDataLayer
{
    public partial class AdvWorksDbContext : DbContext  
    {
            
        public AdvWorksDbContext(DbContextOptions<AdvWorksDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Product> Products { get; set; }          
    }
}