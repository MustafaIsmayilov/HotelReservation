using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Domain.Entities;

public class Room: BaseEntity
{
    public string Number { get; set; } = null!;
    public int Capacity {  get; set; }
    public bool IsAvailable { get; set; } = true;
    
}