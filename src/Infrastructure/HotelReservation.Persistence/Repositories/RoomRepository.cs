using System.Data.Entity;
using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Domain.Entities;
using HotelReservation.Persistence.Contexts;

namespace HotelReservation.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly HotelDbContext _context;
    public RoomRepository(HotelDbContext context) => _context = context;

    public async Task<Room?> GetByIdAsync(Guid id) =>
        await _context.Rooms.FindAsync(id);

    public async Task<IEnumerable<Room>> GetAllAsync(int? minCapacity = null)
    {
        var query = _context.Rooms.AsQueryable();
        if (minCapacity.HasValue)
            query = query.Where(r => r.Capacity >= minCapacity.Value);
        return await query.ToListAsync();
    }

    public async Task AddAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Room room)
    {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Room room)
    {
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
    }
}

