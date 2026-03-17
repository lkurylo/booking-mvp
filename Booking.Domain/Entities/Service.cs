using Booking.Domain.ValueObjects;

namespace Booking.Domain.Entities;

public class Service
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Duration { get; private set; }
    public Money Price { get; private set; }

    private Service() { }

    public Service(Guid id, string name, int duration, Money price)
    {
        Id = id;
        Name = name;
        Duration = duration;
        Price = price;
    }
}