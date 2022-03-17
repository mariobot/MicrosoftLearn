using BlazorProducts.Server.Context.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProducts.Server.Context
{
    public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options)
			:base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new QAConfiguration());
			modelBuilder.ApplyConfiguration(new DeclarationConfiguration());
			modelBuilder.ApplyConfiguration(new ReviewConfiguration());
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Declaration> Declarations { get; set; }

		public DbSet<QA> QAs { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
