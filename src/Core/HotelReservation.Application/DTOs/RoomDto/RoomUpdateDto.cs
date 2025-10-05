namespace HotelReservation.Application.DTOs.RoomDto;

public class RoomUpdateDto
{
    public Guid Id { get; set; }
    public string Number { get; set; } = null!;
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
}
