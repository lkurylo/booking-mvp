using Booking.Application.DTOs;
using Booking.Domain.Interfaces.Repositories;
using MediatR;

namespace Booking.Application.Queries;

public record ListBarbersQuery : IRequest<List<ListBarberDto>>;

public class ListBarbersQueryHandler(IBarberRepository barberRepository) : IRequestHandler<ListBarbersQuery, List<ListBarberDto>>
{
    public async Task<List<ListBarberDto>> Handle(ListBarbersQuery request, CancellationToken cancellationToken)
    {
        var barbers = await barberRepository.GetAllAsync();

        return [.. barbers.Select(b => new ListBarberDto
        (
            Id: b.Id,
            Name: b.Name,
            Specializations: b.Specializations.Select(s =>
                new ServiceDto(s.Id, s.Name, s.Price.Amount)).ToList()
        ))];
    }
}