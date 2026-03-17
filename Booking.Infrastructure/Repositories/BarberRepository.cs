using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using Booking.Infrastruture.Persistence;

namespace Booking.Infrastruture.Repositories;

public class BarberRepository(AppDbContext context) : IBarberRepository
{
    public Task AddAsync(Barber barber)
    {
        throw new NotImplementedException();
    }

    public Task<List<Barber>> GetAllAsync()
    {
        // context.Barbers.ToListAsync();
        throw new NotImplementedException();
    }

    public Task<Barber> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Barber barber)
    {
        throw new NotImplementedException();
    }
}