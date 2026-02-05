using NSubstitute;
using TicketFlow.Modules.Catalog.Application.UseCases.Events;
using TicketFlow.Modules.Catalog.Domain.Entities;
using TicketFlow.Modules.Catalog.Domain.Repositories;

namespace TicketFlow.Modules.Catalog.UnitTests;
public class CreateEventUseCaseTests
{

    [Fact]
    public async Task Handle_Should_Call_Repository_With_Correct_Event()
    {
        //arrange
        var eventRepositoryMock = Substitute.For<IEventRepository>();

        var createEventUseCase = new CreateEventUseCase(eventRepositoryMock);

        var request = new CreateEventRequest("Show do Metallica", "Noite Heavy Metal", DateTime.Now.AddDays(15));

        //act
        var resultId = await createEventUseCase.ExecuteAsync(request);

        //assert
        Assert.NotEqual(Guid.Empty, resultId);

        await eventRepositoryMock.Received(1).AddAsync(Arg.Any<Event>());
        await eventRepositoryMock.Received(1).AddAsync(Arg.Is<Event>(ev => ev.Title == "Show do Metallica"));
    }
}
