using Booking.Domain.ValueObjects;

namespace Booking.Domain.Entities;

public class Barber
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Barber() { }

    public Barber(Guid id, string name, ICollection<Service>? specializations = null)
    {
        Id = id;
        Name = name;
        Specializations = specializations?.ToList() ?? new List<Service>();
    }

    public List<Service> Specializations { get; private set; }
    // public List<TimeSlot> WorkingHours { get; private set; }
}