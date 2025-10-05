namespace HotelReservation.Application.DTOs.RoomDto;

public class RoomCreateDto
{
    public string Number { get; set; } = null!;
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; } = true;
}
