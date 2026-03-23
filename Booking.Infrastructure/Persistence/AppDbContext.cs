using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastruture.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AppointmentEntity> Appointments { get; set; }
    public DbSet<BarberEntity> Barbers { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Guid barberId = Guid.Parse("a47ac10b-58cc-4372-a567-0e02b2c3d479");
        Guid serviceId = Guid.Parse("b47ac10b-58cc-4372-a567-0e02b2c3d479");
        Guid customerId = Guid.Parse("c47ac10b-58cc-4372-a567-0e02b2c3d479");
        Guid appointmentId = Guid.Parse("d47ac10b-58cc-4372-a567-0e02b2c3d479");
        DateTime now = DateTime.Parse("2026-03-23T10:00:00");

        var scheduledTimeStart = now.AddHours(1);
        var scheduledTimeEnd = now.AddHours(1).AddMinutes(20);

        modelBuilder.Entity<CustomerEntity>().HasData(
            new CustomerEntity
            {
                Id = customerId,
                Name = "John Doe",
                Email = "none@example.com"
            }
        );

        var service = new ServiceEntity
        {
            Id = serviceId,
            Name = "Beard Trim",
            DurationMinutes = 20,
            PriceAmount = 110
        };

        modelBuilder.Entity<ServiceEntity>().HasData(
          service
        );

        modelBuilder.Entity<BarberEntity>().HasData(
        new BarberEntity
        {
            Id = barberId,
            Name = "Łukasz",
            // Specializations = [service]
        }
    );
        modelBuilder.Entity<AppointmentEntity>().HasData(
            new AppointmentEntity()
            {
                Id = appointmentId,
                BarberId = barberId,
                CustomerId = customerId,
                ServiceId = serviceId,
                ScheduledTimeStart = scheduledTimeStart,
                ScheduledTimeEnd = scheduledTimeEnd,
                Status = Domain.Enums.AppointmentStatus.Booked,
                Comments = "First appointment"
            });

        modelBuilder.Entity<AppointmentEntity>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.BarberId).IsRequired();
            entity.Property(a => a.CustomerId).IsRequired();
            entity.Property(a => a.ServiceId).IsRequired();
            entity.Property(a => a.ScheduledTimeStart).IsRequired();
            entity.Property(a => a.ScheduledTimeEnd).IsRequired();
            entity.Property(a => a.Status).IsRequired();
            entity.Property(a => a.Comments).HasMaxLength(500);
            entity.HasOne(a => a.Barber)
                .WithMany()
                .HasForeignKey(a => a.BarberId);
            entity.HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustomerId);
            entity.HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId);
        });

        modelBuilder.Entity<BarberEntity>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Name).IsRequired().HasMaxLength(100);
            entity.HasMany(b => b.Specializations)
                .WithMany(s => s.Barbers)
                .UsingEntity(j => j.ToTable("BarberServices"));
        });

        // modelBuilder.Entity<CustomerEntity>(entity =>
        // {
        //     entity.HasKey(c => c.Id);
        //     entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
        //     entity.Property(c => c.Email).IsRequired().HasMaxLength(100);
        // });

        modelBuilder.Entity<ServiceEntity>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s => s.DurationMinutes).IsRequired();
            entity.Property(s => s.PriceAmount).IsRequired();
            // entity.Property
            // entity.OwnsOne(s => s.Price, money =>
            // {
            //     money.Property(m => m.Amount).HasColumnName("PriceAmount").IsRequired();
            //     money.Property(m => m.Currency).HasColumnName("PriceCurrency").IsRequired().HasMaxLength(3);
            // });
        });

        modelBuilder.Entity<ServiceEntity>().HasMany(x => x.Barbers)
            .WithMany(x => x.Specializations)
            .UsingEntity(j => j.ToTable("BarberServices"));
    }
}