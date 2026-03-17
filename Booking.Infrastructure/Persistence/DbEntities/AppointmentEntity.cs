namespace Booking.Infrastruture.Persistence;

public class AppointmentEntity
{
    public Guid Id { get; set; }
    public Guid BarberId { get; set; }
    public Guid ServiceId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime ScheduledTime { get; set; }
    public int Status { get; set; }
}