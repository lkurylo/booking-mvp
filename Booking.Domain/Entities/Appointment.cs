using Booking.Domain.Enums;
using Booking.Domain.Exceptions;
using Booking.Domain.ValueObjects;

namespace Booking.Domain.Entities;

public class Appointment
{
    private Appointment()
    {
    }

    public Appointment(Guid barberId, DateTime startTime)
    {
        if (startTime < DateTime.UtcNow)
        {
            throw new DomainException("Scheduled time must be in the future.");
        }

        Id = Guid.NewGuid();
        BarberId = barberId;
        ScheduledTime = startTime;
        Status = AppointmentStatus.Booked;
    }

    public Guid Id { get; set; }
    public Guid BarberId { get; set; }
    public DateTime ScheduledTime { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public void Cancel(DateTime currentDateTime)
    {
        if (ScheduledTime.AddHours(-2) < currentDateTime)
        {
            throw new DomainException("Cannot cancel appointment less than 2 hours before scheduled time.");
        }

        Status = AppointmentStatus.Cancelled;
    }
}