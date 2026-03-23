using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces.Repositories;

public interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
}