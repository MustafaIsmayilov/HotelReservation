using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Application.Abstracts.Services;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Persistence.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;
    public RoomService(IRoomRepository repo) => _repo = repo;

    public async Task<Room?> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

    public async Task<IEnumerable<Room>> GetAllAsync(int? minCapacity = null) =>
        await _repo.GetAllAsync(minCapacity);

    public async Task<Room> CreateAsync(Room room)
    {
        await _repo.AddAsync(room);
        return room;
    }

    public async Task<Room> UpdateAsync(Room room)
    {
        await _repo.UpdateAsync(room);
        return room;
    }

    public async Task DeleteAsync(Guid id)
    {
        var room = await _repo.GetByIdAsync(id);
        if (room != null)
            await _repo.DeleteAsync(room);
    }
}

