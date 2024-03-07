using Microsoft.EntityFrameworkCore;
using Application.Data;
using Domain.Primitives;
using Domain.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infraestucture.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base (options)
    {
        this.publisher = publisher ?? throw new ArgumentException(nameof(publisher));
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This deffinition prevent to create in database the Domain models
        // instead the deffinition of context will be defined.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e => e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach(var domainEvent in domainEvents)
        {
            await this.publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }
}