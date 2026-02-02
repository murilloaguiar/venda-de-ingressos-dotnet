using Microsoft.EntityFrameworkCore;
using TicketFlow.Modules.Catalog.Domain.Entities;

namespace TicketFlow.Modules.Catalog.Infrastructure.Database;
public class CatalogDbContext: DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options): base(options)
    {
        
    }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);

        modelBuilder.HasDefaultSchema("Catalog");
    }

}
