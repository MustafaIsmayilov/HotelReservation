namespace HotelReservation.Application.DTOs.ReservationDto;

public class ReservationCreateDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Guid> RoomIds { get; set; } = new();
}
