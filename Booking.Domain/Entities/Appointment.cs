using Booking.Domain.Enums;
using Booking.Domain.Exceptions;
using Booking.Domain.ValueObjects;

namespace Booking.Domain.Entities;

public class Appointment
{
    private Appointment()
    {
    }

    public Appointment(Guid barberId, Guid ServiceId, TimeSlot startTime)
    {
        if (startTime.Start < DateTime.UtcNow)
        {
            throw new DomainException("Scheduled time must be in the future.");
        }

        Id = Guid.NewGuid();
        BarberId = barberId;
        ScheduledTime = startTime;
        Status = AppointmentStatus.Booked;
    }

    public Guid Id { get; private set; }
    public Guid BarberId { get; private set; }
    public Guid ServiceId { get; private set; }
    public Guid CustomerId { get; private set; }
    public TimeSlot ScheduledTime { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public void Cancel(DateTime currentDateTime)
    {
        if (ScheduledTime.Start.AddHours(-2) < currentDateTime)
        {
            throw new DomainException("Cannot cancel appointment less than 2 hours before scheduled time.");
        }

        Status = AppointmentStatus.Cancelled;
    }

    public void Complete()
    {
        Status = AppointmentStatus.Completed;
    }

    public void Reschedule(TimeSlot newSlot)
    {
        if (newSlot.Start < DateTime.UtcNow)
        {
            throw new DomainException("New scheduled time must be in the future.");
        }

        if (ScheduledTime.Start.AddHours(-2) < DateTime.UtcNow)
        {
            throw new DomainException("Cannot reschedule appointment less than 2 hours before scheduled time.");
        }

        ScheduledTime = newSlot;
        Status = AppointmentStatus.Booked;
    }
}