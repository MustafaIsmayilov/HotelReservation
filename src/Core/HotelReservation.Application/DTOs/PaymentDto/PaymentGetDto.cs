using HotelReservation.Domain.Enums;

namespace HotelReservation.Application.DTOs.PaymentDto;

public class PaymentGetDto
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
}