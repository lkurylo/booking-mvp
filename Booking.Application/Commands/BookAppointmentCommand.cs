using Booking.Domain.Entities;
using Booking.Domain.Exceptions;
using Booking.Domain.Interfaces.Repositories;
using Booking.Domain.ValueObjects;
using MediatR;

namespace Booking.Application.Commands;

public record BookAppointmentCommand(
    Guid BarberId,
    Guid ServiceId,
    DateTime StartTime) : IRequest<Guid>;

public class BookAppointmentHandler : IRequestHandler<BookAppointmentCommand, Guid>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IBarberRepository _barberRepository;

    public BookAppointmentHandler(
        IAppointmentRepository appointmentRepository,
        IBarberRepository barberRepository)
    {
        _appointmentRepository = appointmentRepository;
        _barberRepository = barberRepository;
    }

    public async Task<Guid> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
    {
        var barber = await _barberRepository.GetByIdAsync(request.BarberId);

        if (barber is null)
        {
            throw new DomainException("Barber not found.");
        }

        var service = barber.Specializations.FirstOrDefault(s => s.Id == request.ServiceId);

        if (service is null)
        {
            throw new DomainException("Barber does not offer the selected service.");
        }

        var appointment = new Appointment(request.BarberId, request.ServiceId,
            new TimeSlot(request.StartTime, request.StartTime.AddMinutes(service.Duration)));

        var appointmentId = await _appointmentRepository.AddAsync(appointment);

        return appointmentId;
    }
}