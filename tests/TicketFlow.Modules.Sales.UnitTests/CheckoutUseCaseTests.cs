using NSubstitute;
using TicketFlow.Modules.Sales.Application.Integrations;
using TicketFlow.Modules.Sales.Application.UseCases.Orders;
using TicketFlow.Modules.Sales.Domain.Entities;
using TicketFlow.Modules.Sales.Domain.Repositories;

namespace TicketFlow.Modules.Sales.UnitTests;

public class CheckoutUseCaseTests
{

    [Fact]
    public async Task Checkout_Should_Create_Order_With_Correct_Total()
    {
        //Arrange
        var repoMock = Substitute.For<IOrderRepository>();
        var catalogGatewayMock = Substitute.For<ICatalogGateway>();

        var eventId = Guid.NewGuid();
        var price = 50m;
        catalogGatewayMock.GetEventPriceAsync(eventId).Returns(price);

        var useCase = new CheckoutUseCase(repoMock, catalogGatewayMock);

        var request = new CheckoutRequest(CustomerId: Guid.NewGuid(), Items: new List<CheckoutItem> { new CheckoutItem(eventId, 2) });

        //Act
        var orderId = await useCase.ExecuteAsync(request);

        //Assert
        Assert.NotEqual(Guid.Empty, orderId);
        await repoMock.Received(1).AddAsync(Arg.Is<Order>(o => o.TotalAmount == 100m));

    }

    [Fact]
    public async Task Checkout_With_Invalid_Event_Should_Throw_ArgumentException()
    {
        var repoMock = Substitute.For<IOrderRepository>();
        var catalogGatewayMock = Substitute.For<ICatalogGateway>();

        catalogGatewayMock.GetEventPriceAsync(Arg.Any<Guid>()).Returns((decimal?)null);

        var useCase = new CheckoutUseCase(repoMock, catalogGatewayMock);
        var request = new CheckoutRequest(CustomerId: Guid.NewGuid(), new List<CheckoutItem> { new CheckoutItem(Guid.NewGuid(), 1) });

        //Act + Assert
        await Assert.ThrowsAsync<ArgumentException>(() => useCase.ExecuteAsync(request));
    }
}
