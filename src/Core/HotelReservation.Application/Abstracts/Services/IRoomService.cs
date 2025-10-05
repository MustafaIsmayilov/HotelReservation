using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Abstracts.Services;

public interface IRoomService
{
    Task<Room?> GetByIdAsync(Guid id);
    Task<IEnumerable<Room>> GetAllAsync(int? minCapacity = null);
    Task<Room> CreateAsync(Room room);
    Task<Room> UpdateAsync(Room room);
    Task DeleteAsync(Guid id);
}
