using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Persistence.Configurations;

public class RoomConfiguration:IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.Number)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.Capacity)
            .IsRequired();

        builder.Property(r => r.IsAvailable)
            .IsRequired()
            .HasDefaultValue(true);

        
    }
}
