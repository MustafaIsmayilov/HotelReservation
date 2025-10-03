using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Persistence.Configurations;

public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FullName)
                 .IsRequired()
                 .HasMaxLength(100);

        builder.Property(c=>c.Email)
                 .IsRequired()
                 .HasMaxLength(100);

        builder.Property(c=>c.Phone)
                 .IsRequired()
                 .HasMaxLength(100);

        builder.HasMany(c => c.Reservations)
            .WithOne(r => r.Customer)
            .HasForeignKey(r => r.CustomerId);
    }
}
