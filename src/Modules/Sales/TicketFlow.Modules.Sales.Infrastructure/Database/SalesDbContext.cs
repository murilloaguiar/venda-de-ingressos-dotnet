using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketFlow.Modules.Sales.Domain.Entities;
using TicketFlow.Shared.Kernel.Abstractions;

namespace TicketFlow.Modules.Sales.Infrastructure.Database;

public class SalesDbContext : DbContext
{
    private readonly IPublisher _publisher;
    public SalesDbContext(DbContextOptions<SalesDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesDbContext).Assembly);
        modelBuilder.HasDefaultSchema("Sales");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        var entitiesWithEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();

        foreach (var entity in entitiesWithEvents)
        {
            var domainEvents = entity.DomainEvents.ToList();
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            entity.ClearDomainEvents();
        }

        return result;
    }
}
