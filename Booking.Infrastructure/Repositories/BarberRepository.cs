using System.Net.Mime;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using Booking.Domain.ValueObjects;
using Booking.Infrastruture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastruture.Repositories;

public class BarberRepository(AppDbContext context) : IBarberRepository
{
    public async Task AddAsync(Barber barber)
    {
        context.Barbers.Add(new BarberEntity
        {
            Id = barber.Id,
            Name = barber.Name,
            Specializations = [.. barber.Specializations.Select(s => new ServiceEntity
            {
                Id = s.Id,
                Name = s.Name,
                DurationMinutes = s.Duration,
                PriceAmount = s.Price.Amount
            })]
        });

        await context.SaveChangesAsync();
    }

    public async Task<List<Barber>> GetAllAsync()
    {
        return await context.Barbers.Select(x =>
            new Barber(x.Id, x.Name, x.Specializations.Select(xx =>
                new Service(xx.Id, xx.Name, xx.DurationMinutes,
                    new Money(xx.PriceAmount, "PLN"))).ToList())).ToListAsync();
    }

    public async Task<Barber?> GetByIdAsync(Guid id)
    {
        return await context.Barbers.Where(x => x.Id == id).Select(x =>
            new Barber(x.Id, x.Name, x.Specializations.Select(xx =>
                new Service(xx.Id, xx.Name, xx.DurationMinutes,
                    new Money(xx.PriceAmount, "PLN"))).ToList())).SingleOrDefaultAsync();
    }

    public Task UpdateAsync(Barber barber)
    {
        throw new NotImplementedException();
    }
}