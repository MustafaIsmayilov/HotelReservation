namespace HotelReservation.Domain.Entities;

public class Reservation : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
