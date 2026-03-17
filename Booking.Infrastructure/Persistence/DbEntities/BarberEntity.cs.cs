namespace Booking.Infrastruture.Persistence;

public class BarberEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime ScheduledTime { get; set; }
    public int Status { get; set; }
}