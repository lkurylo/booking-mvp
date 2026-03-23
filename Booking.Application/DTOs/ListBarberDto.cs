namespace Booking.Application.DTOs;

public record ListBarberDto(Guid Id, string Name, List<ServiceDto> Specializations);