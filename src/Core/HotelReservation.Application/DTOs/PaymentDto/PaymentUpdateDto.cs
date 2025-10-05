using HotelReservation.Domain.Enums;

namespace HotelReservation.Application.DTOs.PaymentDto;

public class PaymentUpdateDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
}
