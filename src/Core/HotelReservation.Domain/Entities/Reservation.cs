namespace HotelReservation.Domain.Entities;

public class Reservation: BaseEntity
{
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
