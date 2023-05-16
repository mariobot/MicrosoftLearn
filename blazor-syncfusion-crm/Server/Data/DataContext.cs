using BlazorSyncfusionCmr.Client.Pages;
using BlazorSyncfusionCmr.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCmr.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MBOTERO\\MBOTERO;Integrated Security=True;database=sycmr;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    NickName = "Spider Man",
                    Place = "NYC",
                    DateOfBirth = new DateTime(2001, 8, 1)
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Tony",
                    LastName = "Stark",
                    NickName = "Iron Man",
                    Place = "LA",
                    DateOfBirth = new DateTime(1975, 8, 1)
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Clark",
                    LastName = "Kent",
                    NickName = "Superman",
                    Place = "NYC",
                    DateOfBirth = new DateTime(1950, 8, 1)
                });

            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, ContactId = 1, Text = "With great power comes great responsability" },
                new Note { Id = 2, ContactId = 2, Text = "I am Iron Man" },
                new Note { Id = 3, ContactId = 3, Text = "To the infinite" });
        }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
