using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketFlow.Modules.Sales.Application.Integrations;
using TicketFlow.Modules.Sales.Application.UseCases.Orders;
using TicketFlow.Modules.Sales.Domain.Repositories;
using TicketFlow.Modules.Sales.Infrastructure.Database;
using TicketFlow.Modules.Sales.Infrastructure.Integrations;
using TicketFlow.Modules.Sales.Infrastructure.Repositories;

namespace TicketFlow.Modules.Sales.Infrastructure;

public static class SalesModuleExtensions
{
    public static IServiceCollection AddSalesModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<SalesDbContext>(options =>
        {
            options.UseSqlServer(connectionString);

        });

        services.AddScoped<IOrderRepository, SqlServerOrderRepository>();
        services.AddScoped<ICatalogGateway, ModuleCatalogGateway>();
        services.AddScoped<CheckoutUseCase>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddMediatR(config =>
        { 
            config.RegisterServicesFromAssembly(typeof(CheckoutUseCase).Assembly);
        }
        );

        return services;
    }

}
