using HotelReservation.Domain.Enums;

namespace HotelReservation.Application.DTOs.PaymentDto;

public class PaymentCreateDto
{
    public Guid ReservationId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
}
