using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            
            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Bebidas", Description = "Categoria de Bebidas" },
                    new Category { CategoryId = 2, Name = "Panaderia", Description = "Categoria de Panaderia" },
                    new Category { CategoryId = 3, Name = "Carnes", Description = "Categoria de Carnes" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product() { ProductId = 1, CategoryId = 1, Name = "Coca Cola", Price = 3000, Quantity = 20 },
                    new Product() { ProductId = 2, CategoryId = 1, Name = "Cerveza", Price = 5000, Quantity = 30 },
                    new Product() { ProductId = 3, CategoryId = 1, Name = "Agua", Price = 1500, Quantity = 50 },
                    new Product() { ProductId = 4, CategoryId = 2, Name = "Pan Tenza", Price = 6500, Quantity = 15 },
                    new Product() { ProductId = 5, CategoryId = 2, Name = "Tostadas Integrales", Price = 3500, Quantity = 25 },
                    new Product() { ProductId = 6, CategoryId = 2, Name = "Pan Frances", Price = 4500, Quantity = 32 },
                    new Product() { ProductId = 7, CategoryId = 3, Name = "Biffe Chorizo", Price = 10500, Quantity = 10 },
                    new Product() { ProductId = 8, CategoryId = 3, Name = "Solomo", Price = 11000, Quantity = 12 },
                    new Product() { ProductId = 9, CategoryId = 3, Name = "Baby Beaf", Price = 12000, Quantity = 15 }
                );


        }
    }
}
