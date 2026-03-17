using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces.Repositories;

public interface IBarberRepository
{
    Task<List<Barber>> GetAllAsync();
    Task<Barber> GetByIdAsync(Guid id);
    Task AddAsync(Barber barber);
    Task UpdateAsync(Barber barber);
}