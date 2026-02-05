using TicketFlow.Modules.Sales.Domain.Entities;

namespace TicketFlow.Modules.Sales.UnitTests;

public class OrderTests
{
    [Fact]
    public void Create_Order_With_Items_Should_Create_Calculate_Total_Correctly()
    {
        //Arrange
        var customerId = Guid.NewGuid();
        var eventId = Guid.NewGuid();
        var pricePerTicket = 100m;
        var quantity = 2;

        //Act
        var order = Order.Create(customerId);
        order.AddItem(eventId, quantity, pricePerTicket);

        //Assert
        Assert.Equal(customerId, order.CustomerId);
        Assert.Equal(200m, order.TotalAmount);
        Assert.Single(order.Items);
    }

    [Fact]
    public void Create_Order_Item_With_Negative_Quantity_Should_Throw_ArgumentException()
    {
        //Arrange
        var order = Order.Create(Guid.NewGuid());

        //Act + Assert
        Assert.Throws<ArgumentException>(() => order.AddItem(Guid.NewGuid(), -1, 50));

    }
}