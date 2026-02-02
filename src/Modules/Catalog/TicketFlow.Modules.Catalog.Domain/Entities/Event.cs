using TicketFlow.Shared.Kernel.Abstractions;

namespace TicketFlow.Modules.Catalog.Domain.Entities;

public class Event : Entity, IAggregateRoot
{
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }

    private Event() { }

    private Event(string title, string description, DateTime date)
    {
        Id = Guid.NewGuid(); 
        Title = title;
        Description = description;
        Date = date;
    }

    public static Event Create(string title, string description, DateTime date)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException("O título não pode ser vazio.", nameof(title));

        if (string.IsNullOrEmpty(description))
            throw new ArgumentException("A descrição não pode ser vazia.", nameof(description));

        if (date < DateTime.Now)
            throw new ArgumentException("A data do evento deve ser futura.", nameof(date));

        return new Event(title, description, date);
    }
}