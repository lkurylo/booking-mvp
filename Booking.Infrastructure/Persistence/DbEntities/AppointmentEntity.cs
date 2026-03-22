using Booking.Domain.Enums;

namespace Booking.Infrastruture.Persistence;

public class AppointmentEntity
{
    public Guid Id { get; set; }
    public Guid BarberId { get; set; }
    public BarberEntity Barber { get; set; }
    public Guid ServiceId { get; set; }
    public ServiceEntity Service{ get; set; }
    public Guid CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }
    public DateTime ScheduledTimeStart { get; set; }
    public DateTime ScheduledTimeEnd { get; set; }
    public AppointmentStatus Status { get; set; }
    public string? Comments { get; set; }
}