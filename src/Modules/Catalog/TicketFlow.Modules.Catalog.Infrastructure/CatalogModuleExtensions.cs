using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TicketFlow.Modules.Catalog.Application.UseCases.Events;
using TicketFlow.Modules.Catalog.Domain.Repositories;
using TicketFlow.Modules.Catalog.Infrastructure.Repositories;
using TicketFlow.Modules.Catalog.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace TicketFlow.Modules.Catalog.Infrastructure;
public static class CatalogModuleExtensions
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IEventRepository, SqlServerEventRepository>();
        services.AddScoped<CreateEventUseCase>();

        return services;
    }
}
