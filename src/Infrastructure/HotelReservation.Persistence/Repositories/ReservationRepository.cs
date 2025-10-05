using System.Data.Entity;
using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Domain.Entities;
using HotelReservation.Persistence.Contexts;

namespace HotelReservation.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly HotelDbContext _context;
    public ReservationRepository(HotelDbContext context) => _context = context;

    public async Task<Reservation?> GetByIdAsync(Guid id) =>
        await _context.Reservations
            .Include(r => r.Rooms)
            .Include(r => r.Payments)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task AddAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Reservation reservation)
    {
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime startDate, DateTime endDate)
    {
        return !await _context.Reservations
            .Where(r => r.Rooms.Any(room => room.Id == roomId))
            .AnyAsync(r => r.StartDate < endDate && startDate < r.EndDate);
    }
}

