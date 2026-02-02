using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketFlow.Modules.Catalog.Domain.Entities;

namespace TicketFlow.Modules.Catalog.Infrastructure.Database.Configuration;
public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(ev => ev.Id);

        builder.Property(ev => ev.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ev => ev.Description)
            .HasMaxLength(500);

        builder.Property(ev => ev.Date)
            .IsRequired();
    }
}
