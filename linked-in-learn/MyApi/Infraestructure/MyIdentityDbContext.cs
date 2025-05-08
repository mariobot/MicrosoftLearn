using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Infraestructure;

public class MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : IdentityDbContext<MyApplicationUser>
{
    
}

public class MyApplicationUser : IdentityUser
{
    // Add custom properties here if needed
}
