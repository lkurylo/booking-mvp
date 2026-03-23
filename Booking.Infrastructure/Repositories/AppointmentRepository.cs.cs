using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using Booking.Infrastruture.Persistence;

namespace Booking.Infrastruture.Repositories;

public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
{
    public async Task AddAsync(Appointment appointment)
    {
        context.Appointments.Add(new AppointmentEntity
        {
            Id = appointment.Id,
            BarberId = appointment.BarberId,
            ServiceId = appointment.ServiceId,
            ScheduledTimeStart = appointment.ScheduledTime.Start,
            ScheduledTimeEnd = appointment.ScheduledTime.Stop,
            Status = appointment.Status
        });

        await context.SaveChangesAsync();
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