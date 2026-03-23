using Booking.Application.DTOs;
using Booking.Domain.Interfaces.Repositories;
using MediatR;

namespace Booking.Application.Queries;

public record ListBarbersQuery : IRequest<List<ListBarberDto>>;

public class ListBarbersQueryHandler(IBarberRepository barberRepository) : IRequestHandler<ListBarbersQuery, List<ListBarberDto>>
{
    public async Task<List<ListBarberDto>> Handle(
        ListBarbersQuery request, CancellationToken cancellationToken)
    {
        // in queries EF Core dbcontext can be used directly, because there is no business
        // logic so there is no point in going through the repository and domain objects,
        // just data retrieval, but for consistency (at least for now)
        // I will use repository here as well
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