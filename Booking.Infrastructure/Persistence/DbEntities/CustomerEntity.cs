namespace Booking.Infrastruture.Persistence;

public class CustomerEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}