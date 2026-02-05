using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Modules.Sales.Domain.Entities;

namespace TicketFlow.Modules.Sales.Infrastructure.Database.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);

        builder.OwnsMany(o => o.Items, itemsBuilder => {
                itemsBuilder.ToTable("OrderItems");
                itemsBuilder.WithOwner().HasForeignKey("OrderId");
                itemsBuilder.HasKey("Id");
                itemsBuilder.Property(i => i.EventId).IsRequired();
            }
        );
    }

}
