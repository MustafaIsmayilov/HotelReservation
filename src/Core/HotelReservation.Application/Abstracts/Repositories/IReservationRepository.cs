using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Abstracts.Repositories;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(Guid id);
    Task AddAsync(Reservation reservation);
    Task DeleteAsync(Reservation reservation);
    Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime startDate, DateTime endDate);
}
