using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastruture.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AppointmentEntity> Appointments { get; set; }
    public DbSet<BarberEntity> Barbers { get; set; }
    // public DbSet<CustomerEntity> Customers { get; set; }
    // public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppointmentEntity>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.BarberId).IsRequired();
            entity.Property(a => a.CustomerId).IsRequired();
            entity.Property(a => a.ServiceId).IsRequired();
            entity.Property(a => a.ScheduledTime).IsRequired();
            entity.Property(a => a.Status).IsRequired();
        });

        modelBuilder.Entity<BarberEntity>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Name).IsRequired().HasMaxLength(100);
        });

        // modelBuilder.Entity<CustomerEntity>(entity =>
        // {
        //     entity.HasKey(c => c.Id);
        //     entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
        //     entity.Property(c => c.Email).IsRequired().HasMaxLength(100);
        // });

        // modelBuilder.Entity<ServiceEntity>(entity =>
        // {
        //     entity.HasKey(s => s.Id);
        //     entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
        //     entity.OwnsOne(s => s.Price, money =>
        //     {
        //         money.Property(m => m.Amount).HasColumnName("PriceAmount").IsRequired();
        //         money.Property(m => m.Currency).HasColumnName("PriceCurrency").IsRequired().HasMaxLength(3);
        //     });
        // });
    }
}