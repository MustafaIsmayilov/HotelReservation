using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Abstracts.Services;

public interface IReservationService
{
    Task<Reservation> CreateReservationAsync(Guid roomId, DateTime startDate, DateTime endDate);
    Task<Reservation?> GetReservationAsync(Guid id);
    Task CancelReservationAsync(Guid id);
}