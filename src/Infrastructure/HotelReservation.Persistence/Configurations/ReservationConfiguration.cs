using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Persistence.Configurations;

public class ReservationConfiguration:IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasMany(r => r.Rooms)
            .WithMany() // Room entity-də navigation collection yoxdur, əgər əlavə etmək istəsən .WithMany(rm => rm.Reservations) yazılacaq
            .UsingEntity<Dictionary<string, object>>(
                "ReservationRoom", // join table adı
                j => j.HasOne<Room>()
                      .WithMany()
                      .HasForeignKey("RoomId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Reservation>()
                      .WithMany()
                      .HasForeignKey("ReservationId")
                      .OnDelete(DeleteBehavior.Cascade)
            );

        builder.Property(r => r.StartDate)
            .IsRequired();

        builder.Property(r => r.EndDate)
            .IsRequired();
    }
}
