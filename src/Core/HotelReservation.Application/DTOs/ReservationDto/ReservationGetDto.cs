using HotelReservation.Application.DTOs.PaymentDto;

namespace HotelReservation.Application.DTOs.ReservationDto;

public class ReservationGetDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<ReservationCreateDto> Rooms { get; set; } = new();
    public List<PaymentGetDto> Payments { get; set; } = new();
}
