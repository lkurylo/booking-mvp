using System;

namespace Booking.Domain.ValueObjects;

public record TimeSlot(DateTime Start, DateTime Stop)
{
    public bool IsOverlapping(TimeSlot other)
    {
        return false;
    }
}