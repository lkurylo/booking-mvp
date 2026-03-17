using Booking.Application.DTOs;
using Booking.Domain.Interfaces.Repositories;
using MediatR;

namespace Booking.Application.Queries;

public record ListBarbersQuery : IRequest<List<BarberDto>>;

public class ListBarbersQueryHandler(IBarberRepository barberRepository) : IRequestHandler<ListBarbersQuery, List<BarberDto>>
{
    public async Task<List<BarberDto>> Handle(ListBarbersQuery request, CancellationToken cancellationToken)
    {
        var barbers = await barberRepository.GetAllAsync();
        return barbers.Select(b => new BarberDto
        {
            Id = b.Id,
            Name = b.Name,
            Specializations = b.Specializations.Select(s => s.Name).ToList()
        }).ToList();
    }
}