namespace HotelReservation.Application.DTOs.ReservationDto;

public class ReservationUpdateDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Guid> RoomIds { get; set; } = new();
}
