using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Infraestructure;

public class MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options, IConfiguration configuration) : IdentityDbContext<MyApplicationUser>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = configuration.GetConnectionString("Identity");
            optionsBuilder.UseSqlite(connectionString);
        }
    }

}




public class MyApplicationUser : IdentityUser
{
    // Add custom properties here if needed
}
