using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using Booking.Infrastruture.Persistence;

namespace Booking.Infrastruture.Repositories;

public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
{
    public Task AddAsync(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public Task<Appointment> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Appointment appointment)
    {
        throw new NotImplementedException();
    }
}