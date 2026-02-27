using TicketFlow.Modules.Catalog.Infrastructure;
using TicketFlow.Modules.Sales.Infrastructure;
using MassTransit;
using TicketFlow.Modules.Notifications.Application.Consumers;
using TicketFlow.Modules.Payments.Application.Consumers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(TicketFlow.Modules.Catalog.Presentation.Controllers.EventsController).Assembly)
    .AddApplicationPart(typeof(TicketFlow.Modules.Sales.Presentation.Controllers.OrdersController).Assembly);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedEventConsumer>();
    x.AddConsumer<ProcessPaymentOnOrderCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("172.31.11.11", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddSalesModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
