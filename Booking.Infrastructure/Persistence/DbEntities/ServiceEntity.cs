namespace Booking.Infrastruture.Persistence;

public class ServiceEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Comments { get; set; }
    public int DurationMinutes { get; set; }
    public decimal PriceAmount { get; set; }
    public ICollection<BarberEntity> Barbers { get; set; }
}