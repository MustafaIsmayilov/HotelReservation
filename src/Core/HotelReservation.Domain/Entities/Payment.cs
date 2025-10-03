using HotelReservation.Domain.Enums;

namespace HotelReservation.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
}
