using TicketFlow.Modules.Catalog.Domain.Entities;

namespace TicketFlow.Modules.Catalog.UnitTests;

public class EventTests
{
    [Fact]
    public void Create_Event_With_Valid_Data_Should_Succeed()
    {
        // Arrange
        var title = "Linkin Park Tour";
        var description = "O melhor show do ano";
        var date = DateTime.Now.AddDays(10);

        // Act
        var ticketEvent = Event.Create(title, description, date);

        // Assert
        Assert.NotNull(ticketEvent);
        Assert.Equal(title, ticketEvent.Title);
        Assert.NotEqual(Guid.Empty, ticketEvent.Id);
    }

    [Fact]
    public void Create_Event_With_InValid_Data_Should_Throws_ArgumentException()
    {
        // Arrange
        var title = "";
        var description = "O melhor show do ano";
        var date = DateTime.Now.AddDays(-2);

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => Event.Create(title, description, date));
    }
}