namespace HotelReservation.Application.DTOs.CustomerDto;

public class CustomerCreateDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}

